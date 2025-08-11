
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class FornecedoresController : ControllerBase
{
    private readonly ApiDbContext _context;

    public FornecedoresController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
    {
        return await _context.Fornecedores.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Fornecedor>> GetFornecedor(Guid id)
    {
        var fornecedor = await _context.Fornecedores.FindAsync(id);
        if (fornecedor == null)
        {
            return NotFound();
        }
        return fornecedor;
    }

    [HttpPost]
    public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
    {
        _context.Fornecedores.Add(fornecedor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor);
    }

    [HttpPut]
    public async Task<IActionResult> PutFornecedor(Guid id, Fornecedor fornecedor)
    {
        if (id != fornecedor.Id)
        {
            return BadRequest();
        }

        _context.Entry(fornecedor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Fornecedores.Any(e => e.Id == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult<Fornecedor>> DeleteFornecedor(Guid id)
    {
        var fornecedor = await _context.Fornecedores.FindAsync(id);
        if (fornecedor == null)
        {
            return NotFound();
        }

        _context.Fornecedores.Remove(fornecedor);
        await _context.SaveChangesAsync();

        return fornecedor;
    }
}