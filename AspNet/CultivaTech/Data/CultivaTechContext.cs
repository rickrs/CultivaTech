using Microsoft.EntityFrameworkCore;
using CultivaTech.Models; // Namespace do modelo Usuario

namespace CultivaTech.Data // Certifique-se de que o namespace está correto
{
    public class CultivaTechContext : DbContext
    {
        public CultivaTechContext(DbContextOptions<CultivaTechContext> options) : base(options)
        {
        }

        // Mapeia o modelo Usuario para a tabela de usuários no banco
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<ItemCarrinho> ItensCarrinho { get; set; }


    }
}