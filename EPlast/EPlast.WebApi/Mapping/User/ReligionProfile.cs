﻿using AutoMapper;
using EPlast.BLL.DTO.UserProfiles;
using EPlast.WebApi.Models.UserModels.UserProfileFields;

namespace EPlast.WebApi.Mapping.User
{
    public class ReligionProfile : Profile
    {
        public ReligionProfile()
        {
            CreateMap<ReligionDTO, ReligionViewModel>().ReverseMap();
        }
    }
}
