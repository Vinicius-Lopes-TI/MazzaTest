using API_Sistema.Model;
using API_Sistema.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Business.Implementation
{
    public class UsuarioBusinessImplementation : IUsuarioBusiness
    {

        private readonly IUsuarioRepository _repository;
        public UsuarioBusinessImplementation(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public Usuario ValidarEmailSenha(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                return null;
            return _repository.ValidarEmailSenha(email, senha);
        }
    }
}
