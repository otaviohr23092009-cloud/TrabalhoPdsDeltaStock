using System.ComponentModel.DataAnnotations;
namespace DeltaStock.DAO
{
    public class FornecedorDAO
    {
        public int IdFornecedor { get; set; }

        [Required(ErrorMessage = "Informe o nome do fornecedor.")]
        [StringLength(150)]
        public string Nome { get; set; } = string.Empty;

       
    }
}
