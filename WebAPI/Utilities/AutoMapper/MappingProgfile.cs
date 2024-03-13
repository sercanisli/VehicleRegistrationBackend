using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebAPI.Utilities.AutoMapper
{
    public class MappingProgfile : Profile
    {
        public MappingProgfile()
        {
            CreateMap<Vehicle, VehicleDto>().ReverseMap();

            CreateMap<VehicleType, VehicleTypeDto>().ReverseMap();

            CreateMap<Brand, BrandDto>().ReverseMap();

            CreateMap<Model, ModelDto>().ReverseMap();
        }
    }
}
