using API_Pets.Context;
using API_Pets.Domains;
using API_Pets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Repositories
{
    public class TipoDePetRepository : ITipoDePet
    {
        // Chamamos a classe de cinexão do banco
        PetsContext conexao = new PetsContext();

        // Chamamos o objeto que poderá receber e executar os comando do banco
        SqlCommand cmd = new SqlCommand();

        public TipoDePet Alterar(int id, TipoDePet t)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE TipoDePet SET " +
                "Descricao = @descricao WHERE IdTipoDePet = @id ";

            cmd.Parameters.AddWithValue("@descricao", t.Descricao);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return t;
        }

        public TipoDePet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoDePet WHERE IdTipoDePet = @id";

            //Atribuimos as variaveis que ve, como argumento
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoDePet t = new TipoDePet();

            while (dados.Read())
            {
                t.IdTipoDePet = Convert.ToInt32(dados.GetValue(0));
                t.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();

            return t;
        }

        public TipoDePet Cadastrar(TipoDePet t)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO TipoDePet (Descricao) " +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", t.Descricao);

            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return t;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM TipoDePet WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<TipoDePet> LerTodos()
        {
            //Abrir conexão 
            cmd.Connection = conexao.Conectar();

            //Preparar query (consulta)
            cmd.CommandText = "SELECT * FROM TipoDePet";

            SqlDataReader dados = cmd.ExecuteReader();

            //Criamos a lista para guardar os alunos
            List<TipoDePet> tipos = new List<TipoDePet>();

            while (dados.Read())
            {
                tipos.Add(
                    new TipoDePet()
                    {
                     IdTipoDePet = Convert.ToInt32(dados.GetValue(0)),
                     Descricao = dados.GetValue(1).ToString()

                    }
                );

            }


            //Fechar conexão
            conexao.Desconectar();

            return tipos;
        }
    }
}
