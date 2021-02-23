using API_Sistema.Model;
using API_Sistema.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Repository.Implementation
{
    public class UsuarioRepositoryImplementation : IUsuarioRepository
    {
        private SQLContext _context;
        public UsuarioRepositoryImplementation(SQLContext context)
        {
            _context = context;
        }
        public Usuario ValidarEmailSenha(string email, string senha)
        {
            return _context.Usuarios
                .SingleOrDefault(x => x.Email.ToLower().Trim() == email.ToLower().Trim() && x.Senha == senha);          

        }
    }
}
