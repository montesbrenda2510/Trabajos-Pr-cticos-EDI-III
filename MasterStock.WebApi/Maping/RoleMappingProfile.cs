using AutoMapper;
using MasterStock.Aplication.Dto.Identity.Role;
using MasterStock.Entitis.MicrosoftIdentity;

namespace MasterStock.WebApi.Maping
{
    public class RoleMappingProfile:Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleResponse>();

            CreateMap<RoleRequet, Role>();
        }
       
      }
    
}
