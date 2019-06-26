using System.Configuration;
using System.Data.SqlClient;
using KuLeuven.GBiomed.Laps.Audit;
using Lithnet.Laps.DirectoryInterfaces;

namespace KuLeuven.GBiomed.Laps.Security.Authorization.Sql
{
    public class SqlAuthorizationService: IAuthorizationService
    {
        /// <summary>
        /// The string that is returned as extra info in the authorization result.
        /// </summary>
        private const string AuthenticationInformation = "via database";

        private static readonly string ConnectionString = null;

        private readonly string authorizationQuery;

        static SqlAuthorizationService()
        {
            var setting = ConfigurationManager.ConnectionStrings["laps"];
            ConnectionString = setting?.ConnectionString;
        }

        public SqlAuthorizationService(string authorizationQuery)
        {
            this.authorizationQuery = authorizationQuery;
        }

        public AuthorizationResponse CanAccessPassword(IUser user, IComputer computer, ITarget target)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(authorizationQuery, connection))
                {
                    var userParameter = new SqlParameter
                    {
                        ParameterName = "@userName",
                        Value = user.SamAccountName
                    };
                    var computerParameter = new SqlParameter
                    {
                        ParameterName = "@computerName",
                        Value = computer.Name
                    };

                    command.Parameters.AddRange(new SqlParameter[]{userParameter, computerParameter});

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.HasRows
                            ? AuthorizationResponse.Authorized(new UsersToNotify(), AuthenticationInformation)
                            : AuthorizationResponse.Unauthorized();
                    }
                }
            }
        }
    }
}