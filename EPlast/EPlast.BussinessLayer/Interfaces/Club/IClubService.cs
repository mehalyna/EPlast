﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EPlast.BussinessLayer.DTO.Club;
using Microsoft.AspNetCore.Http;

namespace EPlast.BussinessLayer.Interfaces.Club
{
    public interface IClubService
    {
        Task<IEnumerable<ClubDTO>> GetAllClubsAsync();
        Task<ClubProfileDTO> GetClubProfileAsync(int clubId);
        Task<ClubDTO> GetClubInfoByIdAsync(int id);
        Task<ClubProfileDTO> GetClubMembersOrFollowersAsync(int clubId, bool isApproved);
        Task UpdateAsync(ClubDTO club, IFormFile file);
        Task UpdateAsync(ClubDTO club);
        Task<ClubDTO> CreateAsync(ClubDTO club, IFormFile file);
        Task<ClubDTO> CreateAsync(ClubDTO club);
    }
}