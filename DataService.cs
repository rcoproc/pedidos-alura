using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly Contexto _contexto;
        public DataService(Contexto contexto)
        {
            // Campo somente leitura
            this._contexto = contexto;
        }

        public void AddItemPedido(int produtoId)
        {
            var produto =
                _contexto.Produtos
                .Where(p => p.Id == produtoId)
                .SingleOrDefault();

            if (produto != null)
            {
                if (!_contexto.ItensPedido
                    .Where(i => i.Produto.Id == produtoId)
                    .Any())
                {
                    _contexto.ItensPedido.Add(new ItemPedido(produto, 1));
                    _contexto.SaveChanges();
                }
            }
        }

        public List<ItemPedido> GetItemPedidos()
        {
            return this._contexto.ItensPedido.ToList();
        }

        public List<Produto> GetProdutos()
        {
            return this._contexto.Produtos.ToList();
        }

        public void InicializaDb()
        {
            // Verifico se o Banco existe
            this._contexto.Database.EnsureCreated();
            if (this._contexto.Produtos.Count() == 0)
            {
                List<Produto> produtos = new List<Models.Produto>
                {
                   new Produto( "Sleep not found", 59.90m),
                   new Produto( "May the code be with you", 59.90m),
                   new Produto( "Rollback", 59.90m),
                   new Produto( "REST", 69.90m),
                   new Produto( "Design Patterns com Java", 69.90m),
                   new Produto( "Vire o jogo com Spring Framework", 69.90m),
                   new Produto( "Test-Driven Development", 69.90m),
                   new Produto( "iOS: Programe para iPhone e iPad", 69.90m),
                   new Produto( "Desenvolvimento de Jogos para Android", 69.90m)
                };

                foreach (var produto in produtos)
                {
                    this._contexto.Produtos.Add(produto);

                    this._contexto.ItensPedido.Add(new ItemPedido(produto, 1));

                }
                this._contexto.SaveChanges();

            }
        }

        public UpdateItemPedidoResponse UpdateItemPedido(ItemPedido itemPedido)
        {
            var itemPedidoDb = _contexto.ItensPedido
                                .Where(i => i.Id == itemPedido.Id)
                                .SingleOrDefault();

            if (itemPedidoDb != null)
            {
                itemPedidoDb.AtualizaQuantidade(itemPedido.Quantidade);

                if (itemPedidoDb.Quantidade == 0)
                    _contexto.ItensPedido.Remove(itemPedidoDb);
            }
            _contexto.SaveChanges();

            var itensPedido = _contexto.ItensPedido.ToList();

            var carrinhoViewModel = new CarrinhoViewModel(itensPedido);

            return new UpdateItemPedidoResponse(itemPedidoDb, carrinhoViewModel);
        }
    }
}
