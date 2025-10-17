using System.ComponentModel.DataAnnotations;

namespace MasterStock.Entitis
{
    public class Categorias
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string NombreCategoria { get; set; }

    }
}
