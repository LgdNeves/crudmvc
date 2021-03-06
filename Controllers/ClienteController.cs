using crudmvc.Data;
using crudmvc.Models;
using crudmvc.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace crudmvc.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
            public IActionResult Index()
        {
            var dbcontext = new Contexto();

            ViewData["clientes"] = dbcontext.Clientes.Where(p => p.Id > 0).ToList();            
            return View();
        }
        [HttpPost]
        public IActionResult Index(Cliente cliente)
        {
            var dbcontext = new Contexto();
            dbcontext.Add(cliente);
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        
        public IActionResult Deletar(Cliente cliente)
        {
            var dbcontext = new Contexto();
            var clienteDelete = dbcontext.Clientes.Find(cliente.Id); 
            dbcontext.Remove(clienteDelete);
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Cliente cliente)
        {
            var dbcontext = new Contexto();
            dbcontext.Update(cliente);
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public IActionResult Atualizar(Cliente novosDadosCliente)
        {
            var dbcontext = new Contexto();

            var antigosDadosCliente = dbcontext.Clientes.Find(novosDadosCliente.Id);

            antigosDadosCliente.Nome = novosDadosCliente.Nome;
            antigosDadosCliente.CPF = novosDadosCliente.CPF;
            antigosDadosCliente.Nascimento = novosDadosCliente.Nascimento;
            antigosDadosCliente.situacao = novosDadosCliente.situacao;

            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        }
}
