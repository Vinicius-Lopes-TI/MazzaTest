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

        public Usuario AtualizarInformacoesUsuario (Usuario usuario)
        {
            if (!Existe(usuario.Id))
                return null;

            var result = _context.Produtos.SingleOrDefault(p => p.Id.Equals(usuario.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(usuario);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return usuario;
        }

        public bool Existe(int id)
        {
            return _context.Usuarios.Any(p => p.Id.Equals(id));
        }
    }
}
