using API_Boletim.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Boletim.Interfaces
{
    interface IMateria
    {
        Materia Cadastrar(Materia a);
        List<Materia> LerTodos();

        Materia BuscarPorId(int id);
        Materia Alterar(Materia a);
        Materia Excluir(Materia a);
    }
}
