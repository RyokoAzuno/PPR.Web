using PPR.CrossCutting.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PPR.CrossCutting.Interfaces
{
    public interface IIdentityUserService : IDisposable
    {
        Task Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto);
    }
}
