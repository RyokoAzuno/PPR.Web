using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using PPR.DAL.EFContext;
using PPR.DAL.Entities;
using PPR.DAL.Interfaces;

namespace PPR.DAL.Repositories
{
    public class IdentityManager : IIdentityManager
    {
        private PPRIdentityContext _db { get; set; }
        private AppUserManager _userManager;
        private AppRoleManager _roleManager;

        public IdentityManager(string connectionString)
        {
            _db = new PPRIdentityContext(connectionString);
            _userManager = new AppUserManager(new UserStore<AppUser>(_db));
            _roleManager = new AppRoleManager(new RoleStore<AppRole>(_db));
        }

        public AppUserManager UserManager
        {
            get { return _userManager; }
        }

        public AppRoleManager RoleManager
        {
            get { return _roleManager; }
        }

        public void Create(AppUser user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
