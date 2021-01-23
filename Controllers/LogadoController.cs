using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using AT_002.Models;

namespace AT_002.Controllers
{
    public class LogadoController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            Repositorio r = new Repositorio();
            Usuario usuario = r.ModoLogin(u);
            if (usuario != null)
            {
                HttpContext.Session.SetInt32("idUsuario", usuario.Id);
                HttpContext.Session.SetString("loginUsuario", usuario.Login);
                HttpContext.Session.SetString("nomeUsuario", usuario.Nome);
                HttpContext.Session.SetString("permissaoUsuario", usuario.Permissao);
                return Redirect("Administrador");
            }
            else
            {
                ViewBag.Mensagem = "Falha no Login";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        public IActionResult Administrador()
        {
            
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            return RedirectToAction("Login");
            if (HttpContext.Session.GetString("permissaoUsuario") == "Funcionário")
            return RedirectToAction("Funcionario");
            return View();
        }
        public IActionResult Funcionario()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            return RedirectToAction("Login");
            return View();
        }
        public IActionResult Listar()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            return RedirectToAction("Login");
            Repositorio r = new Repositorio();
            List<Usuario> usuarios = r.Listar();
            return View(usuarios);
        }
        public IActionResult ListarParaAdm()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            return RedirectToAction("Login");
            if (HttpContext.Session.GetString("permissaoUsuario") == "Funcionário")
            return RedirectToAction("Funcionario");
            Repositorio r = new Repositorio();
            List<Usuario> usuarios = r.Listar();
            return View(usuarios);
        }
        public IActionResult Inserir()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            return RedirectToAction("Login");
            if (HttpContext.Session.GetString("permissaoUsuario") == "Funcionário")
            return RedirectToAction("Funcionario");
            return View();
        }
        [HttpPost]
        public IActionResult Inserir(Usuario u)
        {
            Repositorio r = new Repositorio();
            r.Inserir(u);
            return Redirect("TudoOk");
        }
        public IActionResult Editar()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            return RedirectToAction("Login");
            if (HttpContext.Session.GetString("permissaoUsuario") == "Funcionário")
            return RedirectToAction("Funcionario");
            return View();
        }
        [HttpPost]
        public IActionResult Editar(Usuario u)
        {
            Repositorio r = new Repositorio();
            r.Editar(u);
            return Redirect("TudoOk");
        }
        public IActionResult Excluir()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            return RedirectToAction("Login");
            if (HttpContext.Session.GetString("permissaoUsuario") == "Funcionário")
            return RedirectToAction("Funcionario");
            return View();
        }
        [HttpPost]
        public IActionResult Excluir(Usuario u)
        {
            Repositorio r = new Repositorio();
            r.Excluir(u);
            return Redirect("TudoOk");
        }
        public IActionResult TudoOk()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            return RedirectToAction("Login");
            if (HttpContext.Session.GetString("permissaoUsuario") == "Funcionário")
            return RedirectToAction("Funcionario");
            return View();
        }
        
    }
}