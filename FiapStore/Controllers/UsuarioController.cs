using FiapStore.DTO;
using FiapStore.Entity;
using FiapStore.Enum;
using FiapStore.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioRepository usuarioRepository, ILogger<UsuarioController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-todos-usuario")]
        public IActionResult ObterTodosUsuario()
        {
            try
            {
                return Ok(_usuarioRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "EXCEPTION FORÇADA");
                return BadRequest();
            }
        }

        [Authorize()]
        [HttpGet("obter-todos-com-pedidos/{id}")]
        public IActionResult ObterTodosComPedidos(int id)
        {
            return Ok(_usuarioRepository.ObterComPedidos(id));
        }

        [Authorize]
        [Authorize(Roles = Permissoes.Funcionario)]
        [HttpGet("obter-usuario-por-id/{id}")]
        public IActionResult ObterUsuarioPorId(int id)
        {
            _logger.LogInformation("Executando metodo ObterUsuarioPorId");
            return Ok(_usuarioRepository.ObterPorId(id));
        }


        [Authorize]
        [Authorize(Roles = $"{ Permissoes.Funcionario }, { Permissoes.Administrador }")]
        [HttpPost("cadastrar-usuario")]
        public IActionResult CadastrarUsuario(CadastrarUsuarioDTO usuarioDTO)
        {
            _logger.LogWarning("CUIDADO COM O TEMPO DE REQUISIÇÃO");

            _usuarioRepository.Cadastrar(new Usuario(usuarioDTO));
            return Ok("Usuario Cadastrado com sucesso!");
        }

        [HttpPut("alterar-usuario")]
        public IActionResult AlterarUsuario(AlterarUsuarioDTO alterarUsuarioDTO)
        {
            _usuarioRepository.Alterar(new Usuario(alterarUsuarioDTO));
            return Ok("Usuario alterado com sucesso");
        }

        [HttpDelete("deletar-usuario/{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            _usuarioRepository.Deletar(id);
            return Ok("Usuario deletado com sucesso");
        }
    }
}