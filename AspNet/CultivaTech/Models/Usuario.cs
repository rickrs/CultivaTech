using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CultivaTech.Models
{
    public class Usuario
    {
        [Key] // Define como chave primária
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")] // Torna o campo obrigatório
        [MaxLength(100)] // Define o tamanho máximo do campo
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [MaxLength(150)]
        [EmailAddress] // Valida se é um e-mail válido
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MaxLength(50)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        [MaxLength(20)]
        public string Tipo { get; set; }
    }
}
