using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterStock.Entitis
{
   public class TipodeMovimientos
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string TipodeMovimiento { get; set; }
    }
}
