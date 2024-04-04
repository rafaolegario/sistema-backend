using programacao_do_zero.Models;
using programacao_do_zero.Repositorys;
using programacao_do_zero.Entities;
using programacao_do_zero.Common;
using System;

namespace programacao_do_zero.Services
{
    public class UsuarioService
    {
        private string _connectionString;
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.obterUsuarioPorEmail(email);

            if(usuario != null)
            {
                if (usuario.senha == senha)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.usuarioGuid;

                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "Usuario ou senha invalido";
                }
            }
            else
            {
                result.sucesso = false;
                result.mensagem = "Usuario ou senha invalido";
            }

            return result;
        }
        public CadastroResult Cadastro(string nome,string sobrenome, string telefone, string email, string senha, string genero)
        {
            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.obterUsuarioPorEmail(email);

            if (usuario != null)
            {
                result.sucesso = false;
                result.mensagem = "Usuario ja existe no sistema";

            }
            else
            {
                usuario = new Usuario();
               
                usuario.nome = nome;
                usuario.sobrenome = sobrenome;
                usuario.telefone = telefone;
                usuario.email = email;
                usuario.senha = senha;
                usuario.genero = genero;
                usuario.usuarioGuid = System.Guid.NewGuid();

                var insertResult= usuarioRepository.inserir(usuario);

                if (insertResult > 0)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.usuarioGuid;

                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "ERRO AO ENSERIR O USUARIO";
                }
            }


            return result;
        }
        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario=usuarioRepository.obterUsuarioPorEmail(email);

            if (usuario == null)
            {
                result.sucesso = false;
                result.mensagem = "Usuario não existe";

            }
            else
            {
                result.sucesso = true;
                var emailSender = new EmailSender();
                var assunto = "Recuperação de senha";
                var corpo = "Sua senha atual: " + usuario.senha;
                emailSender.enviar(assunto,corpo,usuario.email);
            }

            return result;
        }
        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);
            return usuario;
        }
    }
}
