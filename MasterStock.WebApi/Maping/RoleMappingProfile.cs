using AutoMapper;
using MasterStock.Aplication.Dto.Identity.Role;
using MasterStock.Entitis.MicrosoftIdentity;

namespace MasterStock.WebApi.Maping
{
    public class RoleMappingProfile:Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleResponse>()
    .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Name));
            CreateMap<RoleRequet, Role>()
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nombre))
    .ForMember(dest => dest.NormalizedName, opt => opt.MapFrom(src => src.Nombre.ToUpper()));
        }
       
      }
    
}
