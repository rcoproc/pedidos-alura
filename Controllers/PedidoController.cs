using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IDataService _dataService;

        public PedidoController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        // GET: /<controller>/carrossel
        public IActionResult Carrossel()
        {
            List<Produto> produtos = _dataService.GetProdutos();
            return View(produtos);
        }

        // GET: /<controller>/carrinho
        public IActionResult Carrinho()
        {
            List<Produto> produtos = this._dataService.GetProdutos();

            var itensCarrinho = this._dataService.GetItemPedidos();

            CarrinhoViewModel viewModel = new CarrinhoViewModel(itensCarrinho);
            return View(viewModel);
        }

        // GET: /<controller>/Resumo
        public IActionResult Resumo()
        {
            return View();
        }
    }
}
