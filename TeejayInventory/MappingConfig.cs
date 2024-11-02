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

                config.CreateMap<CategoryDto, Category>().ReverseMap();
                config.CreateMap<CreateCategoryDto, Category>().ReverseMap();
                config.CreateMap<UpdateCategoryDto, Category>().ReverseMap();

                config.CreateMap<WarehouseDto, Warehouse>().ReverseMap();
                config.CreateMap<CreateWarehouseDto, Warehouse>().ReverseMap();
                config.CreateMap<UpdateWarehouseDto, Warehouse>().ReverseMap();

                config.CreateMap<StockDto, Stock>().ReverseMap();
                config.CreateMap<CreateStockDto, Stock>().ReverseMap();
                config.CreateMap<UpdateStockDto, Stock>().ReverseMap();

                config.CreateMap<SupplierDto, Supplier>().ReverseMap();
                config.CreateMap<CreateSupplierDto, Supplier>().ReverseMap();
                config.CreateMap<UpdateSupplierDto, Supplier>().ReverseMap();


            });
            return mappingConfig;
        }
    }
}
