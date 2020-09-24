using API_EfCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_EfCore.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> Listar();

        Produto BuscarPorId(Guid Id);
        List<Produto> BuscarPorNome(string nome);
        void Adicionar(Produto produto);
        void Editar(Produto produto);
        void Remover(Guid Id);
    }
}
