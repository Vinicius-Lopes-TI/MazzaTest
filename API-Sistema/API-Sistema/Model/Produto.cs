﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Model
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public int IdCategoriaProduto { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        [ForeignKey("IdCategoriaProduto")]
        public virtual CategoriaProduto CategoriaProduto { get; set; }
    }
}
