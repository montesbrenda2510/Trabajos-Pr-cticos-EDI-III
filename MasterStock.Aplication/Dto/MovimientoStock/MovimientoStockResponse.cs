using MasterStock.Entitis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterStock.Aplication.Dto.MovimientoStock
{
    public class MovimientoStockResponse
    {
        public int Id { get; set; }
      
        public int Idproducto { get; set; }
       // public virtual Producto Productos { get; set; }

      
        public string TipodeMoviviento { get; set; }
       
        public int Cantidad { get; set; }

        public DateTime FechadelMovimiento { get; set; }
    }
}
