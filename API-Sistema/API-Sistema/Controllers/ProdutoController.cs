using API_Sistema.Business;
using API_Sistema.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize("Bearer")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoBusiness _produtoBusiness;

        public ProdutoController(
            IProdutoBusiness produtoBusiness)
        {
            _produtoBusiness = produtoBusiness;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _produtoBusiness.ListarTodos();        
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = _produtoBusiness.BuscaPorId(id);
            if (produto == null) return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {
                if (produto == null) return BadRequest();

                var retorno = Ok(_produtoBusiness.Criar(produto));
                return retorno;
            }
            catch(Exception e)
            {                
                return BadRequest(e.Message);
            }            
        }

        [HttpPut]
        public IActionResult Put([FromBody] Produto produto)
        {
            try
            {
                if (produto == null) return BadRequest();

                var retorno = Ok(_produtoBusiness.Atualizar(produto));
                return retorno;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _produtoBusiness.BuscaPorId(id);
            if (produto == null) return BadRequest();

            _produtoBusiness.Deletar(id);
            return Ok("O produto: '"+produto.Descricao +"' foi removido");
        }
    }
}
