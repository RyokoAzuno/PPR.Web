using PPR.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace PPR.DAL.Interfaces
{
    public interface IIdentityManager : IDisposable
    {
        AppUserManager UserManager { get; }
        //AppRoleManager RoleManager { get; }
        void Create(AppUser user);
        Task SaveAsync();
    }
}
