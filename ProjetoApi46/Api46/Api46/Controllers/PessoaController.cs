using Api46.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Api46.Controllers
{
    [RoutePrefix("api")]
    public class PessoaController : ApiController
    {
        Pessoa[] pessoas = new Pessoa[]
        {
            new Pessoa { Id = 1, Nome = "Pessoa1", Ativo = true },
            new Pessoa { Id = 2, Nome = "Pessoa2", Ativo = true },
            new Pessoa { Id = 3, Nome = "Pessoa3", Ativo = false }
        };

        [HttpGet]
        [Route("Pessoa/GetAll")]
        public IEnumerable<Pessoa> GetAll()
        {
            return pessoas;
        }

        [HttpGet]
        [Route("Pessoa/GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var pessoa = pessoas.FirstOrDefault((p) => p.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }
    }
}
