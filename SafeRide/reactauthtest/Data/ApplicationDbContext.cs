using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using reactauthtest.Models;

namespace reactauthtest.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}