using Microsoft.AspNetCore.Mvc;
using SistemaInventario.AccesoDatos.Repositorio;
using SistemaInventario.Modelos;
using SistemaInventario.Modelos.ViewModels;
using SistemaInventario.Utilidades;

namespace SistemaInventario.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductoController(IUnidadTrabajo ut, IWebHostEnvironment webHostEnvironment)
        {
            _unidadTrabajo = ut;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            ProductoVM productoVM = new()
            {
                Producto = new Producto() { Estado = true },
                ListaCategorias = _unidadTrabajo.Producto.ObtenerTodosDropdownList("Categoria"),
                ListaMarcas = _unidadTrabajo.Producto.ObtenerTodosDropdownList("Marca"),
                ListaPadres = _unidadTrabajo.Producto.ObtenerTodosDropdownList("Producto")
            };

            if (id != null)
            {
                productoVM.Producto = await _unidadTrabajo.Producto.Obtener(id.GetValueOrDefault());
                if (productoVM.Producto == null)
                {
                    return NotFound();
                }
            }

            return View(productoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ProductoVM productoVM)
        {
            if(ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;
                if(productoVM.Producto.Id == 0)
                {
                    string upload = webRootPath + DS.RutaImagen;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    productoVM.Producto.ImagenUrl = fileName + extension;   
                    await _unidadTrabajo.Producto.Agregar(productoVM.Producto);
                    TempData[DS.Exitosa] = "Producto añadido exitosamente";
                }
                else
                {
                    var objProducto = await _unidadTrabajo.Producto.ObtenerPrimero(p => p.Id == productoVM.Producto.Id, isTracking:false);
                    if (files.Count > 0)
                    {
                        string upload = webRootPath + DS.RutaImagen;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        var anteriorFile = Path.Combine(upload, objProducto.ImagenUrl);
                        if (System.IO.File.Exists(anteriorFile))
                        {
                            System.IO.File.Delete(anteriorFile);
                        }
                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        productoVM.Producto.ImagenUrl = fileName + extension;
                    }
                    else 
                    {
                        productoVM.Producto.ImagenUrl = objProducto.ImagenUrl;
                    }
                    _unidadTrabajo.Producto.Actualizar(productoVM.Producto);
                    TempData[DS.Exitosa] = "Producto actualizado exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al guardar el Producto";
            productoVM.ListaCategorias = _unidadTrabajo.Producto.ObtenerTodosDropdownList("Categoria");
            productoVM.ListaMarcas = _unidadTrabajo.Producto.ObtenerTodosDropdownList("Marca");
            productoVM.ListaPadres = _unidadTrabajo.Producto.ObtenerTodosDropdownList("Producto");
            return View(productoVM);
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = _unidadTrabajo.Producto.ObtenerTodos(incluirPropiedades: "Categoria,Marca");
            return Json(new { data = todos.Result });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var productoDB = await _unidadTrabajo.Producto.Obtener(id);
            if(productoDB == null)
            {
                return Json(new { success = false, message = "Error al borrar Producto" });
            }

            string upload = _webHostEnvironment.WebRootPath + DS.RutaImagen;
            var anteriorFile = Path.Combine(upload, productoDB.ImagenUrl);
            if (System.IO.File.Exists(anteriorFile))
            {
                System.IO.File.Delete(anteriorFile);
            }
            _unidadTrabajo.Producto.Remover(productoDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Producto borrada exitosamente" });
        }

        [ActionName("ValidarSerie")]
        public async Task<IActionResult> ValidarSerie(string numeroSerie, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Producto.ObtenerTodos();
            if(id == 0)
            {
                valor = lista.Any(b => b.NumeroSerie.ToLower().Trim() == numeroSerie.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.NumeroSerie.ToLower().Trim() == numeroSerie.ToLower().Trim() && b.Id != id);
            }

            return Json(new { data = valor });
        }
        #endregion
    }
}
