using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Models;
using TestJob.Models.Dto;

namespace TestJob
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {       
            CreateMap<CitiesDto, Cities>();
            CreateMap<Cities, CitiesDto>();
            CreateMap<RegionDto, Region>();
            CreateMap<Region, RegionDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<Country, CountryDto>();
        }
    }
    
}
