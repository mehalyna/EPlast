﻿using EPlast.BLL.DTO.Admin;
using EPlast.BLL.DTO.City;
using EPlast.BLL.DTO.Region;
using EPlast.BLL.DTO.UserProfiles;
using EPlast.DataAccess.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EPlast.BLL.Interfaces.Region
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionDTO>> GetAllRegionsAsync();
        Task<RegionDTO> GetRegionByIdAsync(int regionId);
        Task<RegionProfileDTO> GetRegionProfileByIdAsync(int regionId, ClaimsPrincipal user);
        Task DeleteRegionByIdAsync(int regionId);
        Task AddFollowerAsync(int regionId, int cityId);
        Task<IEnumerable<CityDTO>> GetMembersAsync(int regionId);
        Task AddRegionAsync(RegionDTO region);
        Task EditRegionAsync(int regId, RegionDTO region);
        Task<RegionDTO> GetRegionByNameAsync(string Name);
        Task<RegionDocumentDTO> AddDocumentAsync(RegionDocumentDTO documentDTO);
        Task<IEnumerable<RegionDocumentDTO>> GetRegionDocsAsync(int regionId);
        Task<string> DownloadFileAsync(string fileName);
        Task DeleteFileAsync(int documentId);

        Task EndAdminsDueToDate();
        Task<string> GetLogoBase64(string logoName);
        Task RedirectMembers(int prevRegId, int nextRegId);

        /// <summary>
        /// Get all Regions
        /// </summary>
        /// <returns>All Regions</returns>
        Task<IEnumerable<RegionForAdministrationDTO>> GetRegions();


    }
}
