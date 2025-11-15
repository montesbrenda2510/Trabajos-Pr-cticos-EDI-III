using AutoMapper;
using MasterStock.Entitis;
using MasterStock.Aplication.Dto.Categoria;

namespace MasterStock.WebApi.Maping
{
    public class CategoriaMapingProfile : Profile
    {
        public CategoriaMapingProfile()
        {
            CreateMap<Categoria, CategoriaResponse>();
            CreateMap<CategoriaRequest, Categoria>();
        }
    }
}
