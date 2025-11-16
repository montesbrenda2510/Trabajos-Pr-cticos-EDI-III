using AutoMapper;
using MasterStock.Aplication.Dto.Categoria;
using MasterStock.Aplication.Dto.MovimientoStock;
using MasterStock.Entitis;

namespace MasterStock.WebApi.Maping
{
    public class MovimientoStockMappingProfile:Profile
    {
        public MovimientoStockMappingProfile()
        {
            CreateMap<MovimientoStockRequets, MovimientodeStock>();
            CreateMap<MovimientodeStock, MovimientoStockRequets>();
        }
        
    }
}
