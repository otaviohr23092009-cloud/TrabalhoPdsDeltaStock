using System.ComponentModel.DataAnnotations;
namespace DeltaStock.DAO
{
    public class FornecedorDAO
    {
        public int IdFornecedor { get; set; }

        [Required(ErrorMessage = "Informe o nome do fornecedor.")]
        [StringLength(150)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o CNPJ.")]
        [StringLength(18)]
        public string Cnpj { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o telefone.")]
        [StringLength(20)]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe um e-mail válido.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;
    }
}
