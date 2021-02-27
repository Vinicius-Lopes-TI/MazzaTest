using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoProdutos.Models
{
    public class Produto
    {
        public int id { get; set; }
        public int idCategoriaProduto { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public CategoriaProduto categoriaProduto { get; set; }
    }
}