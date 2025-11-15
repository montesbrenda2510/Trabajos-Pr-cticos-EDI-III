using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterStock.Entitis;

namespace MasterStock.Aplication.Dto.MovimientoStock
{
    public class MovimientoStockRequets
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Producto))]
        public int Idproducto { get; set; }
       // public virtual Producto Productos { get; set; }

        [StringLength(30)]
        public string TipodeMoviviento { get; set; }
        [StringLength(30)]
        public int Cantidad { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechadelMovimiento { get; set; }
    }
}
