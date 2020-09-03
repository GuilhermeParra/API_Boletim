using API_Boletim.Context;
using API_Boletim.Domains;
using API_Boletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Boletim.Repositories
{
    public class TrabalhoRepository : ITrabalho
    {

        // Chamamos a classe de cinexão do banco
        BoletimContext conexao = new BoletimContext();

        // Chamamos o objeto que poderá receber e executar os comando do banco
        SqlCommand cmd = new SqlCommand();

        public Trabalho Alterar(Trabalho a)
        {
            throw new NotImplementedException();
        }

        public Trabalho BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Trabalho Cadastrar(Trabalho a)
        {
            throw new NotImplementedException();
        }

        public Trabalho Excluir(Trabalho a)
        {
            throw new NotImplementedException();
        }

        public List<Trabalho> LerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
