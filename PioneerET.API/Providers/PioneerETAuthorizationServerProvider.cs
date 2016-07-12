using Microsoft.Owin.Security.OAuth;
using PioneerET.LDAP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace PioneerET.API.Providers
{
    public class PioneerETAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            // for development purpose this call will be replaced by http call to Pioneer LDAP service
            string path = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, @"App_Data\MockData\ldapusers.json");
            var user = Authenticate.mockValidateUser(context.UserName, context.Password, path);
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("user", context.UserName));
            identity.AddClaim(new Claim("role", user.Role));
            context.Validated(identity);
        }
    }
}