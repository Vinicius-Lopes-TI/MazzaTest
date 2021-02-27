using API_Sistema.Business;
using API_Sistema.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Sistema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize("Bearer")]

    public class UsuarioController : ControllerBase
    {     
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuarioController(ILogger<UsuarioController> logger,
            IUsuarioBusiness usuarioBusiness)
        {
            _logger = logger;
            _usuarioBusiness = usuarioBusiness;
        }

        [HttpGet]
        public IActionResult Get([FromBody] UserVo user)
        {
            var usuario = _usuarioBusiness.ValidarEmailSenha(user.Email, user.Senha);
            if (usuario == null) return NotFound();

            return Ok(usuario);
        }
    }
}
