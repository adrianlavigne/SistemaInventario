using SistemaInventario.Modelos;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        void Actualizar(Categoria categoria);

    }
}
