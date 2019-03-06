using Microsoft.AspNet.Identity.EntityFramework;
using PPR.DAL.Entities;
using PPR.DAL.Initializers;
using System.Data.Entity;

namespace PPR.DAL.EFContext
{
    public class PPRIdentityContext : IdentityDbContext<AppUser>
    {
        public PPRIdentityContext(string connectionString) : base(connectionString)
        {
        }
        static PPRIdentityContext()
        {
            Database.SetInitializer(new PPRIdentityInitializer());
        }
    }
}
