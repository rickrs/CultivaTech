using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CultivaTech.Models
{
    public class Usuario
    {
        [Key] // Define como chave primária
        public int Id { get; set; }

        [Required] // Torna o campo obrigatório
        [MaxLength(100)] // Define o tamanho máximo do campo
        public string Nome { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress] // Valida se é um e-mail válido
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Senha { get; set; }

        [Required]
        [MaxLength(20)]
        public string Tipo { get; set; }
    }
}
