namespace SistemaInventario.AccesoDatos.Repositorio
{
    public interface IUnidadTrabajo: IDisposable
    {
        IBodegaRepositorio Bodega { get; }

        ICategoriaRepositorio Categoria { get; }

        Task Guardar();
    }
}
