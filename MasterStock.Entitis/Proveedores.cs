using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterStock.Entitis
{
    public class Proveedores
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string RazonSocial { get; set; }

        [StringLength(30)]
        public string Telefono { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Direccion { get; set; }


    }
}
