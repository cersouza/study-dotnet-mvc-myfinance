using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class PlanoContaController : Controller
    {
        public IHttpContextAccessor HttpContextAccessor;

        public PlanoContaController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            TempData["Message"] = null;

            string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("usuario.Id");

            PlanoContaModel planoConta = new PlanoContaModel(usuarioId);

            ViewBag.planoConta = planoConta.Listar();

            return View();
        }

        [HttpGet]
        public IActionResult Criar(PlanoContaModel planoConta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("usuario.Id");
                    planoConta.Usuario_Id = usuarioId;

                    var contaCriada = planoConta.Criar();

                    if (contaCriada)
                    {
                        TempData["MessageType"] = "success";
                        TempData["Message"] = "Cadastrado com Sucesso";
                        return RedirectToAction("Index");
                    }
                    else
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

        public IActionResult Editar(int? id)
        {
            try
            {
                string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("usuario.Id");
                var planoConta = new PlanoContaModel(usuarioId);

                var contaAtualizada = planoConta.Editar(id.ToString());

                if (contaAtualizada)
                {
                    TempData["MessageType"] = "success";
                    TempData["Message"] = "Plano Conta atualizado com Sucesso";
                }
                else
                {
                    throw new Exception("Erro ao atualizar Plano de Conta !");
                }

            }
            catch (Exception e)
            {
                TempData["MessageType"] = "danger";
                TempData["Message"] = "Erro ao atualizar Plano de Conta !";
            }

            return View();
        }

        public IActionResult Remover(int? id)
        {
            try
            {
                string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("usuario.Id");
                var planoConta = new PlanoContaModel(usuarioId);

                var contaRemovida = planoConta.Remover(id.ToString());

                if (contaRemovida)
                {
                    TempData["MessageType"] = "success";
                    TempData["Message"] = "Plano Conta removido com Sucesso";
                }
                else
                {
                    throw new Exception("Erro ao remover Plano de Conta !");
                }

            }
            catch (Exception e)
            {
                TempData["MessageType"] = "danger";
                TempData["Message"] = "Erro ao remover Plano de Conta !";
            }

            return RedirectToAction("Index");
        }
    }
}
