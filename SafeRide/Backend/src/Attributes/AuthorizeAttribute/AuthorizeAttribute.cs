using System.Security.Claims;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Backend.Attributes.AuthorizeAttribute;

public static class AuthorizeAttribute
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] {new Claim(claimType, claimValue) };
        }
    }
    
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        readonly Claim _claim;

        public ClaimRequirementFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var securityToken = context.HttpContext.Request.Headers.Authorization;
                var decodedJwt = JwtDecoder.DecodeJwt(securityToken);
                var hasClaim = false;

                if (decodedJwt is not null)
                {
                    hasClaim = decodedJwt.Claims.Any(c => c.Value == _claim.Value);
                }
                
                if (!hasClaim)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    
    }
}