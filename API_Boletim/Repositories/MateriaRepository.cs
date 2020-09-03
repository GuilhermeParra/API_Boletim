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
    public class MateriaRepository : IMateria
    {

        // Chamamos a classe de cinexão do banco
        BoletimContext conexao = new BoletimContext();

        // Chamamos o objeto que poderá receber e executar os comando do banco
        SqlCommand cmd = new SqlCommand();

        public Materia Alterar(Materia a)
        {
            throw new NotImplementedException();
        }

        public Materia BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Materia Cadastrar(Materia a)
        {
            throw new NotImplementedException();
        }

        public Materia Excluir(Materia a)
        {
            throw new NotImplementedException();
        }

        public List<Materia> LerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
