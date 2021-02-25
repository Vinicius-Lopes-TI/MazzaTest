using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Model
{
    [Table("CategoriaProduto")]
    public class CategoriaProduto
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
