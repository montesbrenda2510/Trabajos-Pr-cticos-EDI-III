using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterStock.Aplication.Dto.TipodeMovimiento
{
    public class TipodeMovimientoResponse
    {
        public int Id { get; set; }
        public string TipoMovimiento { get; set; }
    }
}
