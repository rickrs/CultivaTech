using System.ComponentModel.DataAnnotations;

namespace CultivaTech.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Contato é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Contato deve ter no máximo 50 caracteres.")]
        public string Contato { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        [StringLength(200, ErrorMessage = "O Endereço deve ter no máximo 200 caracteres.")]
        public string Endereco { get; set; }
    }
}
