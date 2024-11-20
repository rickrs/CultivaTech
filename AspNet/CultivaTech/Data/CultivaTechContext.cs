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
    }
}