using MySql.Data.MySqlClient;
using programacao_do_zero.Entities;
using System;

namespace programacao_do_zero.Repositorys
{
    public class UsuarioRepository
    {
        private string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int inserir(Usuario usuario)
        {
            var cnn = new MySqlConnection(_connectionString);

            var cmd = new MySqlCommand();
            cmd.Connection = cnn;

            cmd.CommandText = @"INSERT INTO usuario
                (nome,sobrenome,telefone,email,senha,genero,usuarioGuid)
                VALUES
                (@nome, @sobrenome,@telefone,@email,@senha,@genero, @usuarioGuid)";

            cmd.Parameters.AddWithValue("nome", usuario.nome);
            cmd.Parameters.AddWithValue("sobrenome", usuario.sobrenome);
            cmd.Parameters.AddWithValue("telefone", usuario.telefone);
            cmd.Parameters.AddWithValue("email", usuario.email);
            cmd.Parameters.AddWithValue("senha", usuario.senha);
            cmd.Parameters.AddWithValue("genero", usuario.genero);
            cmd.Parameters.AddWithValue("usuarioGuid", usuario.usuarioGuid);

            cnn.Open();

            var affctedRows = cmd.ExecuteNonQuery();

            cnn.Close();

            return affctedRows;
        }
        public Usuario obterUsuarioPorEmail(string email)
        {
            Usuario Usuario = null;
            MySqlConnection cnn = new MySqlConnection(_connectionString);

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnn;

            cmd.CommandText = "SELECT * FROM usuario WHERE email= @email";

            cmd.Parameters.AddWithValue("email", email);

            cnn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Usuario = new Usuario();
                Usuario.Id = Convert.ToInt32(reader["id"]);
                Usuario.nome = reader["nome"].ToString();
                Usuario.sobrenome = reader["sobrenome"].ToString();
                Usuario.telefone = reader["telefone"].ToString();
                Usuario.email = reader["email"].ToString();
                Usuario.senha = reader["senha"].ToString();
                Usuario.genero = reader["genero"].ToString();
                Usuario.usuarioGuid = new Guid(reader["usuarioGuid"].ToString());

            }
            cnn.Close();
            return Usuario;
        }
        public Usuario ObterPorGuid(Guid usuarioGuid)
        {
            Usuario usuario = null;

            var cnn = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand();
           cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM usuario WHERE usuarioGuid= @usuarioGuid";

            cmd.Parameters.AddWithValue("usuarioGuid", usuarioGuid);

            cnn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.Id = Convert.ToInt32(reader["id"]);
                usuario.nome = reader["nome"].ToString();
                usuario.sobrenome = reader["sobrenome"].ToString();
                usuario.telefone = reader["telefone"].ToString();
                usuario.email = reader["email"].ToString();
                usuario.senha = reader["senha"].ToString();
                usuario.genero = reader["genero"].ToString();

                var guid = reader["usuarioGuid"].ToString();
                usuario.usuarioGuid = new Guid(guid);

            }
            cnn.Close();
            return usuario;
        }
    }
} 
