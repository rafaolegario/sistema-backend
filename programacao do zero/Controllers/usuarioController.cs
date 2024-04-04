
using Microsoft.AspNetCore.Mvc;
using programacao_do_zero.Models;
using programacao_do_zero.Services;
using Microsoft.Extensions.Configuration;
using System;

namespace programacaodozero.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class usuarioController : ControllerBase
    {
        private IConfiguration _configuration;
        public usuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {
            var result = new LoginResult();

            if (request == null)
            {
                result.sucesso = false;
                result.mensagem = "PARAMETRO REQUEST VEIO NULO";
            }
            else if (request.email == "")
            {

                result.sucesso = false;
                result.mensagem = "E-mail obrigatorio";
                
            }
            else if (request.senha == "")
            {
                result.sucesso = false;
                result.mensagem = "Senha obrigatorio";
               
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");
                var usurioService = new UsuarioService(connectionString);
                result= usurioService.Login(request.email, request.senha);
                
            }
            return result;
        }

        [Route("cadastro")]
        [HttpPost]
        public CadastroResult cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();
            if (request == null ||
            string.IsNullOrWhiteSpace(request.nome) ||
            string.IsNullOrWhiteSpace(request.sobrenome) ||
            string.IsNullOrWhiteSpace(request.senha) ||
            string.IsNullOrWhiteSpace(request.telefone) ||
            string.IsNullOrWhiteSpace(request.email) ||
            string.IsNullOrWhiteSpace(request.genero))
            {
                result.sucesso = false;
                result.mensagem = "Campos obrigátorios!";

            }
            else{
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Cadastro(request.nome, request.sobrenome, request.telefone, request.email,
                    request.senha, request.genero);
        }
            return result;
        }
          
        [Route("esqueceuSenha")]
        [HttpPost]

        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if(request==null || string.IsNullOrEmpty(request.email))
            {
                result.sucesso = false;
                result.mensagem = "E-mail obrigatorio";

            }
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");
                result = new UsuarioService(connectionString).EsqueceuSenha(request.email);
                   

            return result;
        }

        [Route("obterUsuario")]
        [HttpGet]
        public obterUsuarioResult ObterUsuario( Guid usuarioGuid)
        {
            var result = new obterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.mensagem = "Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");
                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.mensagem = "Usuario não existe";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.nome;
                }
            }
            return result;
        }
    }
}                                     
