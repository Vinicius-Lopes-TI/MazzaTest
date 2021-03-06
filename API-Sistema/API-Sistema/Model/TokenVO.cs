﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Model
{
    public class TokenVO
    {
        public TokenVO(bool authenticated, string created, string expiration, string accessToken, string refreshToken, int idUsuario)
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            IdUsuario = idUsuario;
        }

        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string  Expiration { get; set; }
        public string  AccessToken { get; set; }
        public string  RefreshToken { get; set; }
        public int IdUsuario { get; set; }
    }
}
