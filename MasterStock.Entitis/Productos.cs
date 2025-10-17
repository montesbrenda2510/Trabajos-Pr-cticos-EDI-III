using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterStock.Entitis
{
    public class Productos
    {

        public int Id { get; set; }
        [StringLength(30)]
        public int Codigo { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(30)]

        public string Descripcion { get; set; }

        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public int StockActual { get; set; }
        [ForeignKey(nameof(Categorias))]
        public int IdCategoria { get; set; }
        [ForeignKey(nameof(Proveedor))]
        public int IdProveedor { get; set; }

        public virtual Categorias Categorias { get; set; }
        public virtual Proveedores Proveedor { get; set; }


    }
}
