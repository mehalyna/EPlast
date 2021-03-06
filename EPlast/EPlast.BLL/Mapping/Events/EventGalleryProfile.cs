﻿using AutoMapper;
using EPlast.BLL.DTO.Events;
using EPlast.DataAccess.Entities.Event;

namespace EPlast.BLL.Mapping.Events
{
    class EventGalleryProfile : Profile
    {
        public EventGalleryProfile()
        {
            CreateMap<EventGallary, EventGalleryDTO>()
                .ForMember(d => d.GalleryId, s => s.MapFrom(f => f.GallaryID))
                .ForMember(d => d.FileName, s => s.MapFrom(f => f.Gallary.GalaryFileName));
        }
    }
}
