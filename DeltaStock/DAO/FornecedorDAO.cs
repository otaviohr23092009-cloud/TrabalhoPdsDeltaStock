using System.ComponentModel.DataAnnotations;
namespace DeltaStock.DAO
{
    public class FornecedorDAO
    {
        public int IdFornecedor { get; set; }
        [Required(ErrorMessage = "Informe o nome do fornecedor.")]
        [StringLength(150)]
        public string Nome { get; set; } = string.Empty;
        [StringLength(18)]
        public string Cnpj { get; set; } = string.Empty;

        [StringLength(20)]
        public string Telefone { get; set; } = string.Empty;
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;


    }
}
