using SistemaInventario.Modelos;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public interface IBodegaRepositorio : IRepositorio<Bodega>
    {
        void Actualizar(Bodega bodega);

    }
}
