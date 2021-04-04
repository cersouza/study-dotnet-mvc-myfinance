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
            TempData["Message"] = null;

            string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("usuario.Id");

            ContaModel conta = new ContaModel(usuarioId);

            ViewBag.contas = conta.ListaContas();

            return View();
        }

        [HttpPost]
        public IActionResult CriarConta(ContaModel conta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("usuario.Id");
                    conta.Usuario_Id = usuarioId;

                    var contaCriada = conta.CriarConta();

                    if (contaCriada)
                    {
                        TempData["MessageType"] = "success";
                        TempData["Message"] = "Cadastrado com Sucesso";
                        return RedirectToAction("Index");
                    } else
                    {
                        throw new Exception("Erro ao cadastrar !");
                    }

                }
                catch (Exception e)
                {
                    TempData["MessageType"] = "danger";
                    TempData["Message"] = "Erro ao cadastrar !";
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult CriarConta()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoverConta(int? id)
        {
            try
            {
                string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("usuario.Id");
                var conta = new ContaModel(usuarioId);

                var contaRemovida = conta.RemoverConta(id.ToString());

                if (contaRemovida)
                {
                    TempData["MessageType"] = "success";
                    TempData["Message"] = "Conta removida com Sucesso";
                }
                else
                {
                    throw new Exception("Erro ao remover conta !");
                }

            }
            catch (Exception e)
            {
                TempData["MessageType"] = "danger";
                TempData["Message"] = "Erro ao remover conta !";
            }

            return RedirectToAction("Index");
        }
    }
}
