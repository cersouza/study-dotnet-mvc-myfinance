using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class ContaController : Controller
    {
        public IHttpContextAccessor HttpContextAccessor;

        public ContaController(IHttpContextAccessor httpContextAccessor) {
            HttpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {

            string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("usuario.Id");

            ContaModel conta = new ContaModel(usuarioId);
            
            ViewBag.contas = conta.ListaContas();

            return View();
        }
    }
}
