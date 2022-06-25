using Microsoft.AspNetCore.Mvc;
using ClaytonOliveiraProjeto.Dados;
using ClaytonOliveiraProjeto.Models;

namespace ClaytonOliveiraProjeto.Controllers
{
    public class ManterController : Controller
    {
        ClienteDados _clienteDados = new ClienteDados();
        public IActionResult Listar()
        {
            var oLista = _clienteDados.Listar();
            return View(oLista);
        }
        public IActionResult Salvar()
        {
            return View();
        }
        //exibir um modal para guardar no banco
        [HttpPost]
        public IActionResult Salvar(Cliente ocliente)
        {
            var resposta = _clienteDados.Salvar(ocliente);
            if (resposta)
                return RedirectToAction("Listar");
            else
            return View();
        }
        public IActionResult Editar(int IDCliente)
        {
            var ocliente = _clienteDados.Buscar(IDCliente);
            return View(ocliente);
        }
        [HttpPost]
        public IActionResult Editar(Cliente ocliente)
        {
            var resposta = _clienteDados.Editar(ocliente);
            if (resposta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Excluir(int IDCliente)
        {
            var ocliente = _clienteDados.Buscar(IDCliente);
            return View(ocliente);
        }
        [HttpPost]
        public IActionResult Excluir(Cliente ocliente)
        {
            var resposta = _clienteDados.Excluir(ocliente.Id);
            if (resposta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
