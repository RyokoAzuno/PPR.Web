using Microsoft.AspNet.Identity.EntityFramework;
using PPR.DAL.EFContext;
using PPR.DAL.Entities;
using System.Data.Entity;

namespace PPR.DAL.Initializers
{
    public class PPRIdentityInitializer : DropCreateDatabaseIfModelChanges<PPRIdentityContext>
    {
        protected override async void Seed(PPRIdentityContext context)
        {
            AppUserManager userManager = new AppUserManager(new UserStore<AppUser>(context));
            string password = "Ryoko_Azuno86";
            string login = "admin";

            AppUser user = await userManager.FindByNameAsync(login);
            if (user == null)
            {
                await userManager.CreateAsync(new AppUser { UserName = login }, password);
                await context.SaveChangesAsync();
            }

            base.Seed(context);
        }
    }
}
