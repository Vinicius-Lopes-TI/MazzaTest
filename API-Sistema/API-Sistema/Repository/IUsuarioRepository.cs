using API_Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Repository
{
    public interface IUsuarioRepository
    {
        Usuario ValidarEmailSenha(string email, string senha);

        Usuario AtualizarInformacoesUsuario(Usuario usuario);
    }
}
