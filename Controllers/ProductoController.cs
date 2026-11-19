using DSWI_T1_6.Dtos;
using DSWI_T1_6.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_6.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _productoService.GetProductos();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new RegisterProductoDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterProductoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _productoService.SaveProducto(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _productoService.GetProductoById(id);

            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegisterProductoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _productoService.UpdateProducto(dto);
            return RedirectToAction("Index");
        }
    }
}
