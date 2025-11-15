using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterStock.Abstracions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MasterStock.Entitis
{
    public class MovimientodeStock : IEntidad
    {
        
        public int Id { get; set; }
        [ForeignKey(nameof(Productos))]
        public int Idproducto { get; private set; }
        public virtual Producto Productos { get;private set; }

        [StringLength(30)]
        public string TipodeMoviviento { get; private set; }
        [StringLength(30)]
        public int? Cantidad { get; private set; }

        [DataType(DataType.Date)]
        public DateTime FechadelMovimiento { get; private set; }

        public void SetTipodeMovimiento(string tipoM)
        {
            if (string.IsNullOrWhiteSpace(tipoM))
                throw new ArgumentException("El Tipo de Movimiento no puede estar vacío.");
            TipodeMoviviento = tipoM;
        }

        public void SetCantidad(int cantidad)
        {
            if (cantidad == null || cantidad <= 0)
                throw new ArgumentException("La cantidad no puede estar vacía.");
            Cantidad=cantidad;  
        }

    }
}
