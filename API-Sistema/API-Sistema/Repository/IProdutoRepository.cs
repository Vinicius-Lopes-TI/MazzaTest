using API_Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Repository
{
    public interface IProdutoRepository
    {
        Produto Criar(Produto produto);
        Produto BuscaPorId(int id);

        Produto BuscaPorDescricao(string descricao);
        List<Produto> ListarTodos();
        Produto Atualizar(Produto produto);
        void Deletar(int id);
        bool Existe(int id);
    }
}
