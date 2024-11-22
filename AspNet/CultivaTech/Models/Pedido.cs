using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CultivaTech.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        
        public Usuario Usuario { get; set; } // Relacionamento com a tabela de Usuários

        public string Status { get; set; } = "Pendente";

        // Relacionamentos
        public ICollection<ItemPedido> Itens { get; set; }
    }
}
