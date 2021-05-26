using Disney.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Disney.Identity
{
    public class DisneyIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DisneyIdentityDbContext(DbContextOptions<DisneyIdentityDbContext> options) 
            : base(options)
        {

        }
    }
}
