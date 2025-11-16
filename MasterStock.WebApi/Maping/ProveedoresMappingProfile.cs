using AutoMapper;
using MasterStock.Aplication.Dto.Categoria;
using MasterStock.Aplication.Dto.Preveedor;
using MasterStock.Entitis;

namespace MasterStock.WebApi.Maping
{
    public class ProveedoresMappingProfile : Profile
    {
        public ProveedoresMappingProfile()
        {
            CreateMap<Proveedor, ProveedorResponse>();
            CreateMap<ProveedorResquets, Proveedor>();
        }
    }
}
