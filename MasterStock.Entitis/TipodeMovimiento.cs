using MasterStock.Abstracions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterStock.Entitis
{
    public class TipodeMovimiento:IEntidad
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string TipoMovimiento { get; set; }
    }
}
