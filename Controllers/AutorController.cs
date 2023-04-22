using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AutorController : ControllerBase
{
    private readonly DataContext context;

    public AutorController(DataContext Context)
    {
        context = Context;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Autor model)
    {
        try
        {
            context.Autores.Add(model);
            await context.SaveChangesAsync();
            return Ok("Autor salvo com sucesso.");
        }
        catch
        {
            return BadRequest("Falha ao inserir o Autor.");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Autor>>> Get()
    {
        try
        {
            return Ok(await context.Autores.ToListAsync());
        }
        catch
        {
            return BadRequest("Erro ao obter os Autores.");
        }
    }
}    