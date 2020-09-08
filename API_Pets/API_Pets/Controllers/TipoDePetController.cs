using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Pets.Domains;
using API_Pets.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDePetController : ControllerBase
    {
        //Chamar o repositorio de Raca
        TipoDePetRepository repo = new TipoDePetRepository();
        // GET: api/<RacaController>
        [HttpGet]
        public List<TipoDePet> Get()
        {
            return repo.LerTodos();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public TipoDePet Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public TipoDePet Post([FromBody] TipoDePet t)
        {
            return repo.Cadastrar(t);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public TipoDePet Put(int id, [FromBody] TipoDePet t)
        {
            return repo.Alterar(id, t);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Excluir(id);
        }
    }
}
