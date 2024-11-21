using System.ComponentModel.DataAnnotations;

namespace CultivaTech.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo Quantidade em Estoque é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "A Quantidade deve ser maior ou igual a zero.")]
        public int QuantidadeEmEstoque { get; set; }


        [Display(Name = "Foto do Produto")]
        public string fotoProduto { get; set; }
    }
}
