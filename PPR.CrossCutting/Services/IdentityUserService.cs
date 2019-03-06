using Microsoft.AspNet.Identity;
using PPR.CrossCutting.Interfaces;
using PPR.CrossCutting.Models;
using PPR.DAL.Entities;
using PPR.DAL.Repositories;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PPR.CrossCutting.Services
{
    public class IdentityUserService : IIdentityUserService
    {
        private IdentityManager _manager { get; set; }

        public IdentityUserService(string connectionString)
        {
            _manager = new IdentityManager(connectionString);
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            AppUser user = await _manager.UserManager.FindAsync(userDto.UserName, userDto.Password);
            if (user != null)
                claim = await _manager.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task Create(UserDTO userDto)
        {
            AppUser user = await _manager.UserManager.FindAsync(userDto.UserName, userDto.Password);
            if (user == null)
            {
                user = new AppUser { UserName = userDto.UserName };
                var result = await _manager.UserManager.CreateAsync(user, userDto.Password);
                //await _manager.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                await _manager.SaveAsync();
            }
        }

        public void Dispose()
        {
            _manager.Dispose();
        }

        public async Task SetInitialData(UserDTO adminDto)
        {
            //foreach (string roleName in roles)
            //{
            //    var role = await _manager.RoleManager.FindByNameAsync(roleName);
            //    if (role == null)
            //    {
            //        role = new AppRole { Name = roleName };
            //        await _manager.RoleManager.CreateAsync(role);
            //    }
            //}
            await Create(adminDto);
        }
    }
}
