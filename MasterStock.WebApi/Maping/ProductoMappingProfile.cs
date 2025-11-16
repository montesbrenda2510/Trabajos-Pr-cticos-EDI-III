using AutoMapper;
using MasterStock.Aplication.Dto.Categoria;
using MasterStock.Aplication.Dto.Producto;
using MasterStock.Entitis;

namespace MasterStock.WebApi.Maping
{
    public class ProductoMappingProfile : Profile
    {
        public ProductoMappingProfile()
        {
            CreateMap<Producto, ProductoResponse>();
            CreateMap<ProductoRequets, Producto>();
        }
    }
}
