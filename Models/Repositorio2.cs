

using System.Collections.Generic;
using MySqlConnector;

namespace AT_002.Models
{
    public class Repositorio2
    {
              private const string _strConexao = "Database=atv02;Data Source=localhost;User Id=root;";
        public void Inserir(Usuario2 u)
        {
          MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "INSERT INTO pacote(nome, destinos, atrativos, saida, retorno) VALUES (@Nome, @Destino, @Atrativos, @Saida, @Retorno)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Nome", u.Nome);
            comando.Parameters.AddWithValue("@Destino", u.Destino);
            comando.Parameters.AddWithValue("@Atrativos", u.Atrativos);
            comando.Parameters.AddWithValue("@Saida", u.Saida);
            comando.Parameters.AddWithValue("@Retorno", u.Retorno);

            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void Excluir(Usuario2 u)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "DELETE FROM pacote WHERE id = @Id";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Id", u.Id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void Editar(Usuario2 u)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "UPDATE pacote SET (nome, destinos, atrativos, saida, retorno) VALUES(@Nome, @Destino, @Atrativos, @Saida)";
       
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Nome", u.Nome);
            comando.Parameters.AddWithValue("@Destino", u.Destino);
            comando.Parameters.AddWithValue("@Atrativos", u.Atrativos);
            comando.Parameters.AddWithValue("@Saida", u.Saida);
            comando.Parameters.AddWithValue("@Retorno", u.Retorno);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
          public static void AlterarPacote(Usuario2 u){
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = $"UPDATE pacote SET nome = '{u.Nome}', atrativos = '{u.Atrativos}', saida = '{u.Saida}', retorno = '{u.Retorno}' WHERE id = {u.Id}";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public static List<Usuario2> QueryPacotes(){
           MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sqlSelect = "SELECT * FROM pacote";
            MySqlCommand comandoQuery = new MySqlCommand(sqlSelect, conexao);
            MySqlDataReader resultado = comandoQuery.ExecuteReader();
            List<Usuario2> listaPacotes = new List<Usuario2>();
            while (resultado.Read()){
            Usuario2 pacote = new Usuario2();
                pacote.Nome = resultado.GetString("nome");
                pacote.Atrativos = resultado.GetString("atrativos");
                pacote.Saida = resultado.GetString("saida");
                pacote.Retorno = resultado.GetString("retorno");
                pacote.Id = resultado.GetInt32("id");
                listaPacotes.Add(pacote);
            }
            resultado.Close();
            conexao.Close();
            return listaPacotes;
        }
        
        public List<Usuario2> Listar()
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "SELECT * FROM pacote ORDER BY id";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<Usuario2> lista = new List<Usuario2>();
            while (reader.Read())
            {
                Usuario2 usr = new Usuario2();
                usr.Id = reader.GetInt32("Id");                
                usr.Nome = reader.GetString("Nome");
                usr.Destino = reader.GetString("Destinos");
                usr.Atrativos = reader.GetString("Atrativos");
                usr.Saida = reader.GetString("Saida");
                usr.Retorno = reader.GetString("Retorno");
                lista.Add(usr);
            }      
            {
          conexao.Close();
            return lista;;

    }
}  
}
}