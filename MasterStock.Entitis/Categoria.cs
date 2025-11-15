using MasterStock.Abstracions;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MasterStock.Entitis
{
    public class Categoria : IEntidad
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string NombreCategoria { get; private set; }

        public void SetNombreCategoria(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la Cateegoria no puede estar vacío.");
            NombreCategoria = nombre;
        }

        

    }
}
