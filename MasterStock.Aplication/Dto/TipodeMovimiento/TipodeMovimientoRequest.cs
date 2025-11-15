using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterStock.Aplication.Dto.TipodeMovimiento
{
    public class TipodeMovimientoRequest
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string TipoMovimiento { get; set; }
    }
}
