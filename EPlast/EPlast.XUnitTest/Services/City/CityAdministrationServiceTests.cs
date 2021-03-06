﻿using AutoMapper;
using EPlast.BLL.DTO.City;
using EPlast.BLL.Interfaces.Admin;
using EPlast.BLL.Interfaces.City;
using EPlast.BLL.Services.City;
using EPlast.DataAccess.Entities;
using EPlast.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;
using DatabaseEntities = EPlast.DataAccess.Entities;

namespace EPlast.XUnitTest.Services.City
{
    public class CityAdministrationServiceTests
    {
        private readonly Mock<IRepositoryWrapper> _repositoryWrapper = new Mock<IRepositoryWrapper>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Mock<IAdminTypeService> _adminTypeService = new Mock<IAdminTypeService>();
        private readonly ICityAdministrationService _cityAdministrationService;

        public CityAdministrationServiceTests()
        {
            _cityAdministrationService = new CityAdministrationService(_repositoryWrapper.Object,
                _mapper.Object,
                _adminTypeService.Object,
                null);
        }

        [Fact]
        public async Task GetByCityIdAsyncCorrect()
        {
            // Arrange
            _repositoryWrapper.Setup(r => r.CityAdministration.GetAllAsync(It.IsAny<Expression<Func<DatabaseEntities.CityAdministration, bool>>>(),
                It.IsAny<Func<IQueryable<DatabaseEntities.CityAdministration>, IIncludableQueryable<DatabaseEntities.CityAdministration, object>>>()))
                    .ReturnsAsync(new List<DatabaseEntities.CityAdministration> { new DatabaseEntities.CityAdministration() });

            // Act
            await _cityAdministrationService.GetAdministrationByIdAsync(It.IsAny<int>());

            // Assert
            _mapper.Verify(m => m.Map<IEnumerable<DatabaseEntities.CityAdministration>, IEnumerable<CityAdministrationDTO>>(It.IsAny<IEnumerable<DatabaseEntities.CityAdministration>>()));
        }
    }
}