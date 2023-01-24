using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Web;

namespace Entities
{
    public class TOProdutos : TORetorno
    {
        public int IDProduto { get; set; }
               
        public string Descricao { get; set; }
        public string Situacao { get; set; }
        public DateTime Fabricacao { get; set; }
        public DateTime Validade { get; set; }
        public int CodFornecedor { get; set; }
        public string DescFornecedor { get; set; }
        public string CNPJ { get; set; }
        public int Filtro { get; set; }

    }
    public enum eAtivoInativo : int
    {
        Inativo = 0,
        Ativo = 1,
    }
}
