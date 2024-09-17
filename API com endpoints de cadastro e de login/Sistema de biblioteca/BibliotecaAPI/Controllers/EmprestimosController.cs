// Controllers/EmprestimosController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaApp.Models; // Namespace onde suas entidades estão localizadas
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimosController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public EmprestimosController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/emprestimos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimos()
        {
            // Retorna a lista de empréstimos com Livro e Usuario incluídos
            return await _context.Emprestimos
                .Include(e => e.Livro) // Inclui a entidade Livro associada
                .Include(e => e.Usuario) // Inclui a entidade Usuario associada
                .ToListAsync();
        }

        // GET: api/emprestimos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emprestimo>> GetEmprestimo(int id)
        {
            // Busca o empréstimo específico com Livro e Usuario incluídos
            var emprestimo = await _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return emprestimo;
        }

        // POST: api/emprestimos
        [HttpPost]
        public async Task<ActionResult<Emprestimo>> PostEmprestimo(Emprestimo emprestimo)
        {
            // Adiciona um novo empréstimo
            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();

            // Retorna uma resposta 201 Created com o recurso recém-criado
            return CreatedAtAction(nameof(GetEmprestimo), new { id = emprestimo.Id }, emprestimo);
        }

        // PUT: api/emprestimos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmprestimo(int id, Emprestimo emprestimo)
        {
            if (id != emprestimo.Id)
            {
                return BadRequest();
            }

            // Marca o emprestimo como modificado
            _context.Entry(emprestimo).State = EntityState.Modified;

            try
            {
                // Salva as alterações no banco de dados
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmprestimoExists(id))
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

        // DELETE: api/emprestimos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmprestimo(int id)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            // Remove o empréstimo do banco de dados
            _context.Emprestimos.Remove(emprestimo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Verifica se o empréstimo existe
        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimos.Any(e => e.Id == id);
        }
    }
}
