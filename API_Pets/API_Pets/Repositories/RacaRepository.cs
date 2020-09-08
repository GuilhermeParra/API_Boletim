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
    public class RacaRepository : IRaca
    {
        // Chamamos a classe de cinexão do banco
        PetsContext conexao = new PetsContext();

        // Chamamos o objeto que poderá receber e executar os comando do banco
        SqlCommand cmd = new SqlCommand();

        public Raca Alterar(int id, Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Raca SET " +
                "Descricao = @descricao, "
                + "IdTipoDePet = @idtipodepet WHERE IdRaca = @id ";

            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idtipodepet", r.IdTipoDePet);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return r;
        }

        public Raca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";

            //Atribuimos as variaveis que ve, como argumento
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca r = new Raca();

            while (dados.Read())
            {
                r.IdRaca = Convert.ToInt32(dados.GetValue(0));
                r.Descricao = dados.GetValue(1).ToString();
                r.IdTipoDePet = Convert.ToInt32(dados.GetValue(2));
            }

            conexao.Desconectar();

            return r;
        }

        public Raca Cadastrar(Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Raca (Descricao, IdTipoDePet) " +
                "VALUES" +
                "(@descricao, @idtipodepet)";
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idtipodepet", r.IdTipoDePet);

            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return r;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Raca> LerTodos()
        {
            //Abrir conexão 
            cmd.Connection = conexao.Conectar();

            //Preparar query (consulta)
            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = cmd.ExecuteReader();

            //Criamos a lista para guardar os alunos
            List<Raca> racas = new List<Raca>();

            while (dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(2))

                    }
                );

            }


            //Fechar conexão
            conexao.Desconectar();

            return racas;
        }
    } 
}
