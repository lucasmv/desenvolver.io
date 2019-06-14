using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Ui.Site.Data;
using Dev.Ui.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Ui.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _contexto;

        public TesteCrudController(MeuDbContext contexto) {
            _contexto = contexto;
        }

        public IActionResult Index() {
            var aluno = new Aluno {
                Nome = "Lucas",
                DataNascimento = DateTime.Now,
                Email = "lucas@lucasmagno.net.br"
            };

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            var aluno2 = _contexto.Alunos.Find(aluno.Id);
            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "lucas@lucasmagno.net.br");
            var aluno4 = _contexto.Alunos.Where(a => a.Nome == "Lucas");

            aluno.Nome = "João";
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();

            return View("_Layout");
        }
    }
}