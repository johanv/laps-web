using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Lithnet.Laps.DirectoryInterfaces;
using Lithnet.Laps.Web.Audit;
using Lithnet.Laps.Web.Models;
using Microsoft.IdentityModel.Claims;

namespace Lithnet.Laps.Web.Security.Authorization.Sql
{
    public class SqlAuthorizationService: IAuthorizationService
    {
        /// <summary>
        /// The string that is returned as extra info in the authorization result.
        /// </summary>
        private const string AuthenticationInformation = "via database";

        private static readonly string ConnectionString = null;

        static SqlAuthorizationService()
        {
            var setting = ConfigurationManager.ConnectionStrings["laps"];
            ConnectionString = setting?.ConnectionString;
        }

        public AuthorizationResponse CanAccessPassword(IUser user, IComputer computer, ITarget target)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(Properties.Settings.Default.AuthorizationQuery, connection))
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