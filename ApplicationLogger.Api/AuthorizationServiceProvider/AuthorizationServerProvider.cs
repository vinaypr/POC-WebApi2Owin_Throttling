using ApplicationLogger.Services;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApplicationLogger.Api.AuthorizationServiceProvider
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var service = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILoggerService)) as ILoggerService;
            var application = service.GetUserInfo(context.UserName, context.Password);
            if (application == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
           
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}