using API_Sistema.Model;
using API_Sistema.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Business.Implementation
{
    public class ProdutoBusinessImplementation : IProdutoBusiness
    {
        private readonly IProdutoRepository _repository;
        public ProdutoBusinessImplementation(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public Produto Criar(Produto produto)
        {
            try
            {
                var mensagemInvalido = ValidaCriacaoProduto(produto.Descricao);
                if (mensagemInvalido != "")
                {
                    throw new ArgumentException(mensagemInvalido);
                }
                else
                {
                    return _repository.Criar(produto);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Produto Atualizar(Produto produto)
        {
            var mensagemInvalido = ValidaAtualizacaoProduto(produto);
            if (mensagemInvalido != "")
            {
                throw new ArgumentException(mensagemInvalido);
            }
            else
            {
                return _repository.Atualizar(produto);
            }
        }

        public Produto BuscaPorId(int id)
        {
            return _repository.BuscaPorId(id);
        }        

        public void Deletar(int id)
        {
            _repository.Deletar(id);
        }

        public bool Existe(int id)
        {
            return _repository.Existe(id);
        }

        public List<Produto> ListarTodos()
        {
            return _repository.ListarTodos();
        }

        public string ValidaCriacaoProduto(string descricao)
        {
            var produto = _repository.BuscaPorDescricao(descricao);
            if (produto != null)
                return "Existe um produto com a mesma descrição.";

            return "";
        }

        public string ValidaAtualizacaoProduto(Produto produto)
        {
            var produtoComMesmaDescricao = _repository.BuscaPorDescricao(produto.Descricao);
            if (produtoComMesmaDescricao != null && produtoComMesmaDescricao.Id != produto.Id)
                return "Existe um produto com a mesma descrição já criado no sistema";

            return "";
        }
    }
}
