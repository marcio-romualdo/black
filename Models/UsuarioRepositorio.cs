

using System.Collections.Generic;
using MySqlConnector;

namespace AT_002.Models
{
    public class UsuarioRepositorio
    {
               private const string _strConexao = "Database=atv02;Data Source=localhost;User Id=root;";
    

        
        
          public void Cadastro(itens u)
        {
          MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = $"INSERT INTO compra(nome, telefone, cidade, bairro, numero, bebida, quantidade, descricao) VALUES (@Nome, @Telefone, @Cidade, @Bairro, @Numero, @Bebida, @Quantidade, @Descricao)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Nome", u.Nome);
            comando.Parameters.AddWithValue("@Telefone", u.Telefone);
            comando.Parameters.AddWithValue("@Cidade", u.Cidade);
             comando.Parameters.AddWithValue("@Bairro", u.Bairro);
              comando.Parameters.AddWithValue("@Numero", u.Numero);
              comando.Parameters.AddWithValue("@Bebida", u.Bebida);
             comando.Parameters.AddWithValue("@Quantidade", u.Quantidade);
              comando.Parameters.AddWithValue("@Descricao", u.Descricao);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void ExcluirCompra(itens u)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "DELETE FROM compra WHERE id = @Id";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Id", u.Id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void Editar(itens u)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "UPDATE compra SET (nome, destinos, atrativos, saida, retorno) VALUES(@Nome, @Destino, @Atrativos, @Saida)";
       
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Nome", u.Nome);
          
            comando.ExecuteNonQuery();
            conexao.Close();
        }
          public static void EditarCompra(itens u){
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = $"UPDATE compra SET nome = '{u.Nome}', cidade = '{u.Cidade}', bairro = '{u.Bairro}', numero = '{u.Numero}' WHERE id = {u.Id}";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public static List<itens> QueryPacotes(){
           MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sqlSelect = "SELECT * FROM compra";
            MySqlCommand comandoQuery = new MySqlCommand(sqlSelect, conexao);
            MySqlDataReader resultado = comandoQuery.ExecuteReader();
            List<itens> listaPacotes = new List<itens>();
            while (resultado.Read()){
            itens pacote = new itens();
                pacote.Nome = resultado.GetString("nome");
               
                pacote.Id = resultado.GetInt32("id");
                listaPacotes.Add(pacote);
            }
            resultado.Close();
            conexao.Close();
            return listaPacotes;
        }
        
        public List<itens> Listar()
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "SELECT * FROM compra ORDER BY id";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<itens> lista = new List<itens>();
            while (reader.Read())
            {
                itens usr = new itens();
                usr.Id = reader.GetInt32("Id");                
                usr.Nome = reader.GetString("Nome");
             
                lista.Add(usr);
            }      
            {
          conexao.Close();
            return lista;;

    }


    
}  
}
}