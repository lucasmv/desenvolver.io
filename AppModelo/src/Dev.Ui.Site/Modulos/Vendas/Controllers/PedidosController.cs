using Microsoft.AspNetCore.Mvc;

namespace Dev.Ui.Site.Modulos.Vendas.Controllers {
    [Area("Vendas")]
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}