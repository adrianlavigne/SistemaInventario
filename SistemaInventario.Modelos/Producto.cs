using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Número de serie es Obligatorio")]
        [MaxLength(60)]
        public string NumeroSerie { get; set; }

        [Required(ErrorMessage = "Descripción es Obligatorio")]
        [MaxLength(100)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Precio es Obligatorio")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "Costo es Obligatorio")]
        public double Costo { get; set; }

        public string ImagenUrl { get; set; }

        [Required(ErrorMessage = "Estado es Obligatorio")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "Categoría es Obligatorio")]
        public int CategoriaId { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Marca es Obligatorio")]
        public int MarcaId { get; set; }

        [ForeignKey(nameof(MarcaId))]
        public Marca Marca { get; set; }

        public int? PadreId { get; set; }

        public virtual Producto Padre { get; set; }
    }
}
