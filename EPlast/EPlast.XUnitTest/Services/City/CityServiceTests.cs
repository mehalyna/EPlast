﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using EPlast.BussinessLayer.DTO.City;
using EPlast.BussinessLayer.Services;
using EPlast.DataAccess.Entities;
using EPlast.DataAccess.Repositories;
using Microsoft.AspNetCore.Hosting;
using Moq;
using Xunit;


namespace EPlast.XUnitTest.Services.City
{
    public class CityServiceTests
    {
        private readonly Mock<IRepositoryWrapper> _repoWrapper;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IHostingEnvironment> _env;

        public CityServiceTests()
        {
            _repoWrapper = new Mock<IRepositoryWrapper>();
            _mapper = new Mock<IMapper>();
            _env = new Mock<IHostingEnvironment>();
        }

        private CityService CreateCityService()
        {
            _mapper.Setup(m => m.Map<IEnumerable<DataAccess.Entities.City>,
                    IEnumerable<CityDTO>>(It.IsAny<IEnumerable<DataAccess.Entities.City>>()))
                .Returns(CreateFakeCityDto(10));
            _mapper.Setup(m => m.Map<DataAccess.Entities.City, CityDTO>(It.IsAny<DataAccess.Entities.City>()))
                .Returns(CreateFakeCityDto(10).FirstOrDefault());
            _repoWrapper.Setup(r => r.City.FindAll())
                .Returns(CreateFakeCities(10));
            _repoWrapper.Setup(r => r.City.FindByCondition(It.IsAny<Expression<Func<DataAccess.Entities.City, bool>>>()))
                .Returns((Expression<Func<DataAccess.Entities.City, bool>> condition) =>
                    CreateFakeCities(10).Where(condition));
            return new CityService(_repoWrapper.Object, _mapper.Object, _env.Object);
        }

        [Fact]
        public void GetAllTest()
        {
            CityService cityService = CreateCityService();

            var result = cityService.GetAll();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllDtoTest()
        {
            CityService cityService = CreateCityService();

            var result = cityService.GetAllDTO();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetByIdTest()
        {
            CityService cityService = CreateCityService();

            var result = cityService.GetById(GetIdForSearch);

            Assert.NotNull(result);
            Assert.IsType<CityDTO>(result);
        }

        [Fact]
        public void CityProfileTest()
        {
            CityService cityService = CreateCityService();

            var result = cityService.CityProfile(GetIdForSearch);

            Assert.NotNull(result);
            Assert.IsType<CityProfileDTO>(result);
        }

        [Fact]
        public void CityMembersTest()
        {
            CityService cityService = CreateCityService();

            var result = cityService.CityMembers(GetIdForSearch);

            Assert.NotNull(result);
            Assert.IsType<CityProfileDTO>(result);
        }

        [Fact]
        public void CityFollowersTest()
        {
            CityService cityService = CreateCityService();

            var result = cityService.CityFollowers(GetIdForSearch);

            Assert.NotNull(result);
            Assert.IsType<CityProfileDTO>(result);
        }

        [Fact]
        public void CityDocumentsTest()
        {
            CityService cityService = CreateCityService();

            var result = cityService.CityDocuments(GetIdForSearch);

            Assert.NotNull(result);
            Assert.IsType<CityProfileDTO>(result);
        }

        [Fact]
        public void EditGetTest()
        {
            CityService cityService = CreateCityService();

            var result = cityService.Edit(GetIdForSearch);

            Assert.NotNull(result);
            Assert.IsType<CityProfileDTO>(result);
        }

        [Fact]
        public void EditPostTest()
        {
            CityService cityService = CreateCityService();

            var result = cityService.Edit(GetIdForSearch);

            Assert.NotNull(result);
            Assert.IsType<CityProfileDTO>(result);
        }

        private static int GetIdForSearch => 1;
        public IQueryable<DataAccess.Entities.City> CreateFakeCities(int count)
        {
            List<DataAccess.Entities.City> cities = new List<DataAccess.Entities.City>();

            for (int i = 0; i < count; i++)
            {
                cities.Add(new DataAccess.Entities.City());
            }

            return cities.AsQueryable();
        }

        public IQueryable<CityDTO> CreateFakeCityDto(int count)
        {
            List<CityDTO> cities = new List<CityDTO>();

            for (int i = 0; i < count; i++)
            {
                cities.Add(new CityDTO
                {
                    CityAdministration = new List<CityAdministrationDTO>
                    {
                        new CityAdministrationDTO
                        {

                           AdminType = new AdminType
                           {
                               AdminTypeName = "Голова Станиці"
                           }

                        },
                        new CityAdministrationDTO
                        {
                            AdminType = new AdminType
                            {
                                AdminTypeName = "----------"
                            }
                        },
                        new CityAdministrationDTO
                        {
                            AdminType = new AdminType
                            {
                                AdminTypeName = "Голова Станиці"
                            }
                        },
                        new CityAdministrationDTO
                        {
                            AdminType = new AdminType
                            {
                                AdminTypeName = "----------"
                            }
                        }
                    },
                    CityMembers = new List<CityMembersDTO>
                    {
                        new CityMembersDTO
                        {
                            StartDate = new Random().Next(0,1) ==1 ? DateTime.Today : (DateTime?) null
                        }
                    },
                    CityDocuments = new List<CityDocumentsDTO>
                    {
                        new CityDocumentsDTO(),
                        new CityDocumentsDTO(),
                        new CityDocumentsDTO(),
                        new CityDocumentsDTO(),
                        new CityDocumentsDTO()
                    }
                });
            }

            return cities.AsQueryable();
        }

    }
}
