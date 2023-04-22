using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class LeitorController : ControllerBase
{
    private readonly DataContext context;

    public LeitorController(DataContext Context)
    {
        context = Context;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Leitor model)
    {
        try
        {
            context.Leitores.Add(model);
            await context.SaveChangesAsync();
            return Ok("Leitor salvo com sucesso");
        }
        catch
        {
            return BadRequest("Falha ao inserir o Leitor.");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Leitor>>> Get()
    {
        try
        {
            return Ok(await context.Leitores.ToListAsync());
        }
        catch
        {
            return BadRequest("Erro ao obter os Leitores.");
        }
    }
}    