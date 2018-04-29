using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        List<Produto> produtos = new List<Models.Produto>
        {
           new Produto( 1, "Sleep not found", 59.90m),
           new Produto( 2, "May the code be with you", 59.90m),
           new Produto( 3, "Rollback", 59.90m),
           new Produto( 4, "REST", 69.90m),
           new Produto( 5, "Design Patterns com Java", 69.90m),
           new Produto( 6, "Vire o jogo com Spring Framework", 69.90m),
           new Produto( 7, "Test-Driven Development", 69.90m),
           new Produto( 8, "iOS: Programe para iPhone e iPad", 69.90m),
           new Produto( 9, "Desenvolvimento de Jogos para Android", 69.90m)
        };
        // GET: /<controller>/carrossel
        public IActionResult Carrossel()
        {

            return View(produtos);
        }

        // GET: /<controller>/carrinho
        public IActionResult Carrinho()
        {
            var itensCarrinho = new List<ItemPedido>
            {
                new ItemPedido(1, produtos[0], 1),
                new ItemPedido(2, produtos[1], 2),
                new ItemPedido(3, produtos[2], 3),
                new ItemPedido(4, produtos[2], 10)
            };
            return View(itensCarrinho);
        }

        // GET: /<controller>/Resumo
        public IActionResult Resumo()
        {
            return View();
        }
    }
}
