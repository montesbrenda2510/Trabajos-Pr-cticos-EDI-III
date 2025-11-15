using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterStock.Aplication.Dto.Categoria
{
    public class CategoriaResponse
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string NombreCategoria { get; set; }
    }
}
