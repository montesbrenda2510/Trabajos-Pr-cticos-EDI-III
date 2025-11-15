using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterStock.Aplication.Dto.Preveedor
{
    public class ProveedorResponse
    {
        public int Id { get; set; }

        public string RazonSocial { get; set; }

      
        public string Telefono { get; set; }

  
        public string Email { get; set; }

        public string Direccion { get; set; }
    }
}
