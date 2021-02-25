using API_Sistema.Model;
using API_Sistema.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Repository.Implementation
{
    public class ProdutoRepositoryImplementation : IProdutoRepository
    {
        private SQLContext _context;
        public ProdutoRepositoryImplementation(SQLContext context)
        {
            _context = context;
        }

        public Produto Criar(Produto produto)
        {
            try
            {
                _context.Add(produto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return produto;
        }

        public Produto Atualizar(Produto produto)
        {
            if (!Existe(produto.Id))
                return null;

            var result = _context.Produtos.SingleOrDefault(p => p.Id.Equals(produto.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(produto);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return produto;
        }

        public Produto BuscaPorId(int id)
        {
            return _context.Produtos.SingleOrDefault(p => p.Id.Equals(id));
        }

        public void Deletar(int id)
        {
            var produto = _context.Produtos.SingleOrDefault(p => p.Id.Equals(id));
            if (produto != null)
            {
                try
                {
                    _context.Remove(produto);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Existe(int id)
        {
            return _context.Produtos.Any(p => p.Id.Equals(id));
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }

        public Produto BuscaPorDescricao(string descricao)
        {
            return _context.Produtos.FirstOrDefault(p => p.Descricao.ToLower().Equals(descricao.ToLower()));
        }
    }
}
