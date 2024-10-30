using AutoMapper;

using System.Numerics;
using TeejayInventory.Models;
using TeejayInventory.Models.Dto;

namespace TeejayInventory
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
                config.CreateMap<CreateProductDto, Product>().ReverseMap();
                config.CreateMap<UpdateProductDto, Product>().ReverseMap();


            });
            return mappingConfig;
        }
    }
}
