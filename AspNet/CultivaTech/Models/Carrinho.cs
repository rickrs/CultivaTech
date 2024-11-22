using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CultivaTech.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        
        public int UsuarioId { get; set; }

        // Relacionamentos
        public Usuario Cliente { get; set; }
        public ICollection<ItemCarrinho> Itens { get; set; }

    }
}
