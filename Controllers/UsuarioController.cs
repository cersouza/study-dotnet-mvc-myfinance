using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;
using MyFinance.Utils;

namespace MyFinance.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Login(int? id)
        {
            if (id == 0)
            {
                HttpContext.Session.Clear();
            }
            return View();
        }

        [HttpPost]
        public IActionResult ValidarLogin(UsuarioModel usuario)
        {
            bool validado = usuario.ValidarLogin();

            if (validado)
            {
                HttpContext.Session.SetString("usuario.Nome", usuario.Nome);
                HttpContext.Session.SetString("usuario.Id", usuario.Id.ToString());
                HttpContext.Session.SetString("usuario.Data_Nascimento", usuario.Data_Nascimento.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["MensagemUsuarioInválido"] = "Dados inválidos";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Registrar(UsuarioModel usuario)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarUsuario(UsuarioModel usuario)
        {
            usuario.CriarUsuario();
            return RedirectToAction("Login");
        }
    }
}
