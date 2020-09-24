using API_EfCore.Contexts;
using API_EfCore.Domains;
using API_EfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_EfCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }
        /// <summary>
        /// Busca um produto pelo seu Id
        /// </summary>
        /// <param name="Id">Id do produto</param>
        /// <returns>Lista de produto</returns>
        public Produto BuscarPorId(Guid Id)
        {
            try
            {
                //return _ctx.Produtos.FirstOrDefault(c => c.Id == Id);
                return _ctx.Produtos.Find(Id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca o produto pelo nome 
        /// </summary>
        /// <param name="nome">Nome dp produto</param>
        /// <returns>Um produto</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">Produto a ser editado</param>

        public void Editar(Produto produto)
        {
            try
            {
                //Buscar produto pelo Id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //Verifica se o produto existe
                if(produtoTemp == null)
                {
                    throw new Exception("Produto não encontrado");

                }

                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Altera produto no contexto
                _ctx.Produtos.Update(produtoTemp);
                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos os produtos cadastrados
        /// </summary>
        /// <returns>Retorna uma Lista de Produtos</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produto">Objeto do tipo Produto</param>

        public void Adicionar(Produto produto)
        {
            try
            { //Adiciona objeto do tipo produto ao dbset do contexto
                _ctx.Produtos.Add(produto);
                //_ctx.Set<Produto>().Update(produto);

                //Salva as alterações
                _ctx.SaveChanges();

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="Id">Id do produto</param>
        public void Remover(Guid Id)
        {
            try
            {
                //Buscar produto pelo Id
                Produto produtoTemp = BuscarPorId(Id);

                //Verifica se o produto existe
                if (produtoTemp == null)
                {
                    throw new Exception("Produto não encontrado");

                }
                //Remove o produto do DbSet
                _ctx.Produtos.Remove(produtoTemp);
                _ctx.SaveChanges();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message)
            };
        }

        
    }
}
