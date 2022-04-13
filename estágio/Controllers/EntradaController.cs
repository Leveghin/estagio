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

        [HttpPost]
        public async Task<ActionResult<IEnumerable<entidades>>> Getentidade()

        {

            return await _context.entidade.ToListAsync();

        }
        [HttpPost("{Serviço}")]

        public async Task<ActionResult<entidades>> PostEntidades(entidades Entidades)
        {
            _context.entidade.Add(Entidades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getentidade", new { Nome = Entidades.nome }, Entidades);
        }
        [HttpDelete("{Deletar}")]
        public async Task<IActionResult> Deleteentidades(string nome)
        {
            var Entidades = await _context.entidade.FindAsync(nome);
            if (Entidades == null)
            {
                return NotFound();
            }

            _context.entidade.Remove(Entidades);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}


