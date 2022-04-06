using estágio.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace estágio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EntradaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntradaController(AppDbContext context)
        {
            _context = context;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<entidades>>> Getentidade()

        {

            return await _context.entidade.ToListAsync();

        }
        [HttpGet("{Nome}")]
        public async Task<ActionResult<entidades>> Getentidade(string nome)

        {

            var entidade = await _context.entidade.FindAsync(nome);

            if (entidade == null)
            {
                return NotFound();

            }
            return entidade;

        }

        [HttpGet("{Nome}")]
        public async Task<IActionResult> PutEntidade(string nome, entidades entidade)

        {


            if (nome != entidade.nome)
            {
                return BadRequest();

            }
            _context.Entry(entidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!entidadesExists(nome))
                {

                    return NotFound();

                }
                else
                {

                    throw;

                }

            }
            return NoContent();

        }
    }
}
