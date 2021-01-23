using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AT_002.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
namespace AT_002.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
         public IActionResult Contato()
        {
            return View();
        }
        public IActionResult QuemSomos()
        {
            return View();
        }
        public IActionResult Carrinho()
        {
            return View();
        }
          public IActionResult Editar()
        {
            return View();
        }
         public IActionResult Concluido()
        {
            return View();
        }
       
         public IActionResult Cadastro()
        {
            return View();
        }
      

        public IActionResult Bebida_pagina()
        {
            return View("Bebida_pagina");
        }
             [HttpPost]
        public IActionResult Cadastro(itens u)
        {
            UsuarioRepositorio r = new UsuarioRepositorio();
            r.Cadastro(u);
            return Redirect("Concluido");
        }
        
       public IActionResult Listar()
        {
           
            UsuarioRepositorio r = new UsuarioRepositorio();
            List<itens> itens = r.Listar();
            return View(itens);
        }
         
         [HttpPost]
        public IActionResult Editar (itens u){
            HttpContext.Session.SetInt32("Edit", u.Id);
            return RedirectToAction("AlterarPacote");
            
        }
      
         [HttpPost]
        public IActionResult EditarCompra(itens u){
        itens persistencia = new itens();
            persistencia.Id = (int)HttpContext.Session.GetInt32("Edit");
            persistencia.Nome = u.Nome;
            persistencia.Telefone = u.Telefone;
            persistencia.Bairro = u.Bairro;
            persistencia.Bebida = u.Bebida;
            persistencia.Cidade = u.Cidade;
            persistencia.Numero = u.Numero;
            persistencia.Quantidade = u.Quantidade;
            persistencia.Descricao = u.Descricao;
            UsuarioRepositorio.EditarCompra(persistencia);
            return RedirectToAction("Editar");
        }
        
    }
}
