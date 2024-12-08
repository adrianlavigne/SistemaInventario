using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaInventario.Modelos.ViewModels
{
    public class ProductoVM
    {
        public Producto Producto { get; set; }
        public IEnumerable<SelectListItem> ListaMarcas { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
        public IEnumerable<SelectListItem> ListaPadres { get; set; }
    }
}
