﻿using EPlast.BussinessLayer.DTO.UserProfiles;
using System.Collections.Generic;

namespace EPlast.BussinessLayer.Interfaces.UserProfiles
{
    public interface IDegreeService
    {
       IEnumerable<DegreeDTO> GetAll();
    }
}