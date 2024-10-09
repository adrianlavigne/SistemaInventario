using SistemaInventario.Modelos;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public interface IMarcaRepositorio : IRepositorio<Marca>
    {
        void Actualizar(Marca marca);

    }
}
