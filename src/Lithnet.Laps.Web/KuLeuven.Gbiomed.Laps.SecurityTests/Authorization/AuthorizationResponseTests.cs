using NUnit.Framework;
using System;

namespace KuLeuven.GBiomed.Laps.Security.Authorization.Tests
{
    [TestFixture()]
    public class AuthorizationResponseTests
    {
        [Test()]
        public void UsersToNotifyOfAuthorizationResponseShouldNotBeNull()
        {
            // I would love to use Nullable References, but I think this is not possible for Asp.Net?
            var result = AuthorizationResponse.Authorized(null, String.Empty);
            Assert.IsNotNull(result.UsersToNotify);
        }
    }
}