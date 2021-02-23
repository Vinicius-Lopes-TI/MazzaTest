using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
