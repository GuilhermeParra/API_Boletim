using API_Boletim.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Boletim.Interfaces
{
    interface ITrabalho
    {
        Trabalho Cadastrar(Trabalho a);
        List<Trabalho> LerTodos();

        Trabalho BuscarPorId(int id);
        Trabalho Alterar(Trabalho a);
        Trabalho Excluir(Trabalho a);
    }
}
