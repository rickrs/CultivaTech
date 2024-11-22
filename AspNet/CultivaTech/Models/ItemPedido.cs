﻿namespace CultivaTech.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        // Relacionamentos
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}
