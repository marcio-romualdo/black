

using System.Collections.Generic;
using MySqlConnector;

namespace AT_002.Models
{
    public class Repositorio
    {
        private const string _strConexao = "Database=atv02;Data Source=localhost;User Id=root;";
        public Usuario ModoLogin (Usuario u)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "SELECT * FROM usuario WHERE login = @Login AND senha = @Senha";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            comandoQuery.Parameters.AddWithValue("@Login", u.Login);
            comandoQuery.Parameters.AddWithValue("@Senha", u.Senha);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            Usuario usr = null;
            if (reader.Read())
            {
                usr = new Usuario();
                usr.Id = reader.GetInt32("Id");
                if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
                    usr.Nome = reader.GetString("Nome");
                if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                    usr.Login = reader.GetString("Login");
                if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
                    usr.Senha = reader.GetString("Senha");
                if (!reader.IsDBNull(reader.GetOrdinal("Permissao")))
                    usr.Permissao = reader.GetString("Permissao"); 
            }
            conexao.Close();
            return usr;
        }
        public void Inserir(Usuario u)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "INSERT INTO usuario(nome, login, senha, permissao) VALUES (@Nome, @Login, @Senha, @Permissao)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Nome", u.Nome);
            comando.Parameters.AddWithValue("@Login", u.Login);
            comando.Parameters.AddWithValue("@Senha", u.Senha);
            comando.Parameters.AddWithValue("@Permissao", u.Permissao);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void Excluir(Usuario u)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "DELETE FROM usuario WHERE id = @Id";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Id", u.Id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void Editar(Usuario u)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "UPDATE usuario SET nome = @Nome, login = @Login, senha = @Senha, permissao = @Permissao WHERE id = @Id";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Id", u.Id);
            comando.Parameters.AddWithValue("@Nome", u.Nome);
            comando.Parameters.AddWithValue("@Login", u.Login);
            comando.Parameters.AddWithValue("@Senha", u.Senha);
            comando.Parameters.AddWithValue("@Permissao", u.Permissao);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<Usuario> Listar()
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "SELECT * FROM usuario ORDER BY id";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<Usuario> lista = new List<Usuario>();
            while (reader.Read())
            {
                Usuario usr = new Usuario();
                usr.Id = reader.GetInt32("Id");                
                if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
                    usr.Nome = reader.GetString("Nome");
                if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                    usr.Login = reader.GetString("Login");
                if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
                    usr.Senha = reader.GetString("Senha");
                if (!reader.IsDBNull(reader.GetOrdinal("Permissao")))
                    usr.Permissao = reader.GetString("Permissao");
                lista.Add(usr);
            }
            conexao.Close();
            return lista;
        }
           public static List<Usuario> QueryPacotes(){
           MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sqlSelect = "SELECT * FROM usuario";
            MySqlCommand comandoQuery = new MySqlCommand(sqlSelect, conexao);
            MySqlDataReader resultado = comandoQuery.ExecuteReader();
            List<Usuario> listaPacotes = new List<Usuario>();
            while (resultado.Read()){
            Usuario pacote = new Usuario();
                pacote.Nome = resultado.GetString("nome");
                pacote.Id = resultado.GetInt32("id");
                listaPacotes.Add(pacote);
            }
            resultado.Close();
            conexao.Close();
            return listaPacotes;
        }
    }
}