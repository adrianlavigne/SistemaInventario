using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [MaxLength(60, ErrorMessage = "Nombre sólo puede tener un máximo de 60 caractéres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripción es obligatorio")]
        [MaxLength(100, ErrorMessage = "Descripción sólo puede tener un máximo de 100 caractéres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Estado es obligatorio")]
        public bool Estado { get; set; }
    }
}
