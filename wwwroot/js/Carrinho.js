class Carrinho {
  clickIncremento(btn) {
    let data = this.getData(btn);
    data.Quantidade++;
    this.postQuantidade(data);
  }

  clickDecremento(btn) {
    let data = this.getData(btn);
    data.Quantidade--;
    this.postQuantidade(data);
  }

  updateQuantidade(input) {
    let data = this.getData(input);
    this.postQuantidade(data);
  }

  getData(elemento) {
    let linhaItem = $(elemento).parents('[item-id]');
    let itemId = linhaItem.attr('item-id');
    let textValor = linhaItem.find('input');
    let Qtde = textValor.val();

    return {
      Id: itemId,
      Quantidade: Qtde
    }

  }

  postQuantidade(data) {
    $.ajax({
      url: '/pedido/postquantidade',
      type: 'POST',
      contentType: 'application/json',
      data: JSON.stringify(data)
    }).done(function (response) {
      this.setQuantidade(response.itemPedido);
      this.setSubTotal(response.itemPedido);
      this.setTotal(response.carrinhoViewModel);
      this.setNumeroItens(response.carrinhoViewModel);
      if (response.itemPedido.quantidade == 0)
        this.removeItem(response.itemPedido);
    }.bind(this));
  }

  setQuantidade(itemPedido) {
    this.getLinhaDoItem(itemPedido)
      .find('input').val(itemPedido.quantidade);
  }

  setSubTotal(itemPedido) {
    this.getLinhaDoItem(itemPedido)
      .find('[subtotal]').html(itemPedido.subtotal.duasCasas());
  }

  setTotal(carrinhoViewModel) {
    $('[total]').html(carrinhoViewModel.total.duasCasas());
  }

  setNumeroItens(carrinhoViewModel) {
    var texto = 'Total: ' +
      carrinhoViewModel.itens.length
      + (carrinhoViewModel.itens.length > 1 ? ' itens' : 'item' );
    $('[numero-itens]').html(texto);
  }

  getLinhaDoItem(itemPedido) {
    return $('[item-id=' + itemPedido.id + ']')
  }

  removeItem(itemPedido) {
    this.getLinhaDoItem(itemPedido).remove();
  }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
  return this.toFixed(2).replace('.', ',');
}