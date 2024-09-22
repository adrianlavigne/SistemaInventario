using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class BodegaRepositorio : Repositorio<Bodega>, IBodegaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public BodegaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;  
        }
        public void Actualizar(Bodega bodega)
        {
            var bodegaBD = _db.Bodegas.FirstOrDefault(x => x.Id == bodega.Id);
            if (bodegaBD != null)
            {
                bodegaBD.Descripcion = bodega.Descripcion;
                bodegaBD.Estado = bodega.Estado;
                bodegaBD.Nombre = bodega.Nombre;
                _db.SaveChanges();
            }
        }
    }
}
