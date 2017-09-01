using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiCore.Models;
using Microsoft.AspNetCore.Cors;

namespace ApiCore.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {
        private readonly PessoaContext _context;

        public PessoaController(PessoaContext context)
        {
            _context = context;

            if (_context.Pessoas.Count() == 0)
            {
                _context.Pessoas.Add(new Pessoa { Nome = "Pessoa1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Pessoa> GetAll()
        {
            return _context.Pessoas.ToList();
        }

        [HttpGet("{id}", Name = "GetPessoa")]
        public IActionResult GetById(int id)
        {
            var item = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pessoa item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Pessoas.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Pessoa item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var pessoa = _context.Pessoas.FirstOrDefault(atual => atual.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            pessoa.Ativo = item.Ativo;
            pessoa.Nome = item.Nome;

            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(atual => atual.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
