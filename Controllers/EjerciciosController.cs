using DSWI_T1_6.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_6.Controllers
{
    public class EjerciciosController : Controller
    {
        [HttpGet]
        public IActionResult Moto()
        {
            return View(new MotoViewModel());
        }

        [HttpPost]
        public IActionResult Moto(MotoViewModel modelo)
        {
            modelo.PagoMartes = modelo.PrecioMoto - (modelo.PrecioMoto * 0.12m);
            modelo.PagoSabado = modelo.PrecioMoto - (modelo.PrecioMoto * 0.18m);
            modelo.PagoFeriado = modelo.PrecioMoto - (modelo.PrecioMoto * 0.25m);
            return View(modelo);
        }

        [HttpGet]
        public IActionResult Energia()
        {
            return View(new EnergiaViewModel());
        }

        [HttpPost]
        public IActionResult Energia(EnergiaViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            decimal kwh = modelo.Kwh;
            decimal subtotal;

            if (kwh <= 100)
            {
                subtotal = kwh * 0.10m;
            }
            else if (kwh <= 250)
            {
                subtotal = (100 * 0.10m) + ((kwh - 100) * 0.15m);
            }
            else
            {
                subtotal = (100 * 0.10m) + (150 * 0.15m) + ((kwh - 250) * 0.22m);
            }

            decimal tasa = kwh > 500 ? 0.08m : 0.03m;

            modelo.Subtotal = subtotal;
            modelo.Impuesto = subtotal * tasa;
            modelo.Total = modelo.Subtotal + modelo.Impuesto;
            return View(modelo);
        }
    }
}
