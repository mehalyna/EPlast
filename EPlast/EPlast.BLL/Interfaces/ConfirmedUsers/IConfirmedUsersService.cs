﻿using System.Security.Claims;
using System.Threading.Tasks;

namespace EPlast.BLL.Services.Interfaces
{
    public interface IConfirmedUsersService
    {
        Task CreateAsync(ClaimsPrincipal user, string userId, bool isClubAdmin = false, bool isCityAdmin = false);
        Task DeleteAsync(int confirmedUserId);
    }
}
