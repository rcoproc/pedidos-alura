using CasaDoCodigo.Models;
using System.Collections.Generic;

namespace CasaDoCodigo
{
    public interface IDataService
    {
        void InicializaDb();
        List<Produto> GetProdutos();
        List<ItemPedido> GetItemPedidos();
        UpdateItemPedidoResponse UpdateItemPedido(ItemPedido itemPedido);
        void AddItemPedido(int produtoId);
    }
}