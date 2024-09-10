using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Modelos
{
    public class Bodega
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [MaxLength(60, ErrorMessage = "Permite hasta 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion es obligatorio")]
        [MaxLength(100, ErrorMessage = "Permite hasta 100 caracteres")]
        public string Descripcion { get; set;}

        [Required(ErrorMessage = "Estado es obligatorio")]
        public bool Estado { get; set;}
    }
}
