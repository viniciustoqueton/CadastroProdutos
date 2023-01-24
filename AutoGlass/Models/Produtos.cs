
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AutoGlass.Models
{
    [Table("Produtos")]
    public class Produtos
    {
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória", AllowEmptyStrings = false)]
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime Fabricacao { get; set; }
        public DateTime Validade { get; set; }
        public int CodFornecedor { get; set; }
        public string DescFornecedor { get; set; }
        public string CNPJ { get; set; }

    }
    public enum eAtivoInativo : int
    {
        Inativo = 0,
        Ativo = 1,       
    }
}