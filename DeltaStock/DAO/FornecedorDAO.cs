using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeltaStock.DAO
{
    /// <summary>
    /// Módulo: Gestão de Fornecedores
    /// Responsável: [Seu Nome]
    /// Trabalho de PDS - Cadastro de Registros
    /// </summary>
    public class FornecedorDAO
    {
        #region Propriedades e Validações de Cadastro

        public int IdFornecedor { get; set; }

        [Required(ErrorMessage = "Informe o nome do fornecedor.")]
        [StringLength(150)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o CNPJ do fornecedor.")]
        [StringLength(18)]
        public string Cnpj { get; set; } = string.Empty;

        [StringLength(20)]
        public string Telefone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        #endregion
    }
}