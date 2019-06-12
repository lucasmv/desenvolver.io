﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Ui.Site.Modulos.Produtos.Controllers
{
    [Area("Produtos")]
    [Route("produtos")]
    public class CadastroController : Controller
    {
        [Route("")]
        [Route("lista")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("busca")]
        public IActionResult Busca()
        {
            return View();
        }
    }
}