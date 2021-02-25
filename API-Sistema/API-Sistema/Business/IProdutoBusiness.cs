using API_Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Business
{
    public interface IProdutoBusiness
    {
        Produto Criar(Produto produto);
        Produto BuscaPorId(int id);
        List<Produto> ListarTodos();
        Produto Atualizar(Produto produto);
        void Deletar(int id);
        bool Existe(int id);
    }
}
