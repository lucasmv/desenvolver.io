using Dev.Ui.Site.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dev.Ui.Site.Controllers {
    public class HomeController : Controller {
        private readonly IPedidoRepository _pedidoRepository;

        public HomeController(IPedidoRepository pedidoRepository) {
            _pedidoRepository = pedidoRepository;
        }
        public IActionResult Index([FromServices] IPedidoRepository _pedidoRepository) {
            var pedido = _pedidoRepository.ObterPedido();

            return View();
        }
    }
}