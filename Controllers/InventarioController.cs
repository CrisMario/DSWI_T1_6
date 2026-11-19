using DSWI_T1_6.Dtos;
using DSWI_T1_6.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSWI_T1_6.Controllers
{
    public class InventarioController : Controller
    {
        private readonly IInventarioService _inventarioService;
        private readonly IProductoService _productoService;

        public InventarioController(IInventarioService inventarioService, IProductoService productoService)
        {
            _inventarioService = inventarioService;
            _productoService = productoService;
        }

        private async Task CargarProductos(int? productoId = null)
        {
            var productos = await _productoService.GetProductos();
            ViewBag.Productos = new SelectList(productos, "ProductoId", "Nombre", productoId);
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _inventarioService.GetInventarios();
            var productos = await _productoService.GetProductos();
            ViewBag.Nombres = productos.ToDictionary(p => p.ProductoId, p => p.Nombre);
            return View(lista);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await CargarProductos();
            return View(new RegisterInventarioDto { FechaIngreso = DateTime.Today });
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterInventarioDto dto)
        {
            if (!ModelState.IsValid)
            {
                await CargarProductos(dto.ProductoId);
                return View(dto);
            }

            await _inventarioService.SaveInventario(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _inventarioService.GetInventarioById(id);

            if (dto == null)
            {
                return NotFound();
            }

            await CargarProductos(dto.ProductoId);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegisterInventarioDto dto)
        {
            if (!ModelState.IsValid)
            {
                await CargarProductos(dto.ProductoId);
                return View(dto);
            }

            await _inventarioService.UpdateInventario(dto);
            return RedirectToAction("Index");
        }
    }
}
