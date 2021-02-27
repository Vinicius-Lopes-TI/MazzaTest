using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoProdutos.Models
{
    public class ResponseToken
    {
        public bool authenticated { get; set; }
        public string created { get; set; }
        public string expiration { get; set; }
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public int idUsuario { get; set; }
    }
}