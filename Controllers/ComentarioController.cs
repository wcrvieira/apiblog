using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ComentarioController : ControllerBase
{

    private readonly DataContext context;

    public ComentarioController(DataContext Context)
    {
        context = Context;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Comentario model)
    {
        try
        {
            context.Comentarios.Add(model);
            await context.SaveChangesAsync();
            return Ok("Comentário salvo com sucesso.");
        }
        catch
        {
            return BadRequest("Falha ao inserir o Comentário.");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comentario>>> Get()
    {
        try
        {
            return Ok(await context.Comentarios.ToListAsync());
        }
        catch
        {
            return BadRequest("Erro ao obter os Comentários.");
        }
    }


}