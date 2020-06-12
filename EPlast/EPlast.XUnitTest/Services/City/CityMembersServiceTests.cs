﻿using AutoMapper;
using EPlast.BussinessLayer.DTO.City;
using EPlast.BussinessLayer.Services.City;
using EPlast.BussinessLayer.Services.Interfaces;
using EPlast.DataAccess.Repositories;
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
    public class CityMembersServiceTests
    {
        private readonly Mock<IRepositoryWrapper> _repositoryWrapper = new Mock<IRepositoryWrapper>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly ICityMembersService _cityMembersService;

        public CityMembersServiceTests()
        {
            _cityMembersService = new CityMembersService(_repositoryWrapper.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetCurrentByCityIdAsyncCorrect()
        {
            // Arrange
            _repositoryWrapper.Setup(r => r.CityMembers.GetAllAsync(It.IsAny<Expression<Func<DatabaseEntities.CityMembers, bool>>>(),
                It.IsAny<Func<IQueryable<DatabaseEntities.CityMembers>, IIncludableQueryable<DatabaseEntities.CityMembers, object>>>()))
                    .ReturnsAsync(new List<DatabaseEntities.CityMembers> { new DatabaseEntities.CityMembers() });

            // Act
            await _cityMembersService.GetCurrentByCityIdAsync(It.IsAny<int>());

            // Assert
            _mapper.Verify(m => m.Map<IEnumerable<DatabaseEntities.CityMembers>, IEnumerable<CityMembersDTO>>(It.IsAny<IEnumerable<DatabaseEntities.CityMembers>>()));
        }
    }
}