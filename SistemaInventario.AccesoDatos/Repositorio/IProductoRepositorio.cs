using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventario.Modelos;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        void Actualizar(Producto producto);

        IEnumerable<SelectListItem> ObtenerTodosDropdownList(string obj);

    }
}
