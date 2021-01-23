
using System.Collections.Generic;
using AT_002.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public class PacoteController : Controller
    {
        private readonly ILogger<PacoteController> _logger;

        public PacoteController(ILogger<PacoteController> logger)
        {
            _logger = logger;
        }
         public IActionResult EditarPacotes()
        {
            return View();
        } 
         public IActionResult AlterarPacote()
        {
            return View();
        } 


        [HttpPost]
        public IActionResult Inserir(Usuario2 u)
        {
            Repositorio2 r = new Repositorio2();
            r.Inserir(u);
            return Redirect("ok");
        }
       public IActionResult Listar()
        {
           
            Repositorio2 r = new Repositorio2();
            List<Usuario2> usuarios = r.Listar();
            return View(usuarios);
        }

    
         [HttpPost]
        public IActionResult Excluir(Usuario2 u)
        {
            Repositorio2 r = new Repositorio2();
            r.Excluir(u);
            return Redirect("ok");
        }
       
        [HttpPost]
        public IActionResult EditarPacotes(Usuario2 a){
            HttpContext.Session.SetInt32("PacoteEdit", a.Id);
            return RedirectToAction("AlterarPacote");
            
        }
      
        
        [HttpPost]
        public IActionResult AlterarPacote(Usuario2 u){
        Usuario2 persistencia = new Usuario2();
            persistencia.Id = (int)HttpContext.Session.GetInt32("PacoteEdit");
            persistencia.Nome = u.Nome;
            persistencia.Destino = u.Destino;
            persistencia.Atrativos = u.Atrativos;
            persistencia.Saida = u.Saida;
            persistencia.Retorno = u.Retorno;
            Repositorio2.AlterarPacote(persistencia);
            return RedirectToAction("ok");
        }
public IActionResult Pacotes(){
            ViewData["Title"] = "Pacotes";
            return View();
        }
       
    
        public IActionResult Pacote(){
            ViewData["Title"] = "Pacote";
            return View();
        }
     public IActionResult Adm()
        {
            return View();
        }  
        
          

        public IActionResult Inserir()
        {
            return View();
        }  

         public IActionResult ok()
        {
            return View();
        } 
         public IActionResult Excluir()
        {
            return View();
        }
       
        
          

    }





    

