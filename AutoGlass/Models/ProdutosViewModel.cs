using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;


namespace AutoGlass.Models
{
    public class ProdutosViewModel
    {
        public TOProdutos Produtos { get; set; }
        public List<TOProdutos> ListaProdutos { get; set; }
    }
}
