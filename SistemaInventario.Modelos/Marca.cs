using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Modelos
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [MaxLength(60, ErrorMessage = "Permite hasta 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Estado es obligatorio")]
        public bool Estado { get; set;}
    }
}
