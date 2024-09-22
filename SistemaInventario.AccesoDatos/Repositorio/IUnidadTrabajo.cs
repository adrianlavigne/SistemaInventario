namespace SistemaInventario.AccesoDatos.Repositorio
{
    public interface IUnidadTrabajo: IDisposable
    {
        IBodegaRepositorio Bodega { get; }

        Task Guardar();
    }
}
