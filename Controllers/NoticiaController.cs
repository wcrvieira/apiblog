using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class NoticiaController : ControllerBase
{

    private readonly DataContext context;

    public NoticiaController(DataContext Context)
    {
        context = Context;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Noticia model)
    {
        try
        {
            context.Noticias.Add(model);
            await context.SaveChangesAsync();
            return Ok("Notícia salva com sucesso.");
        }
        catch
        {
            return BadRequest("Falha ao inserir a Notícia.");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Noticia>>> Get()
    {
        try
        {
            return Ok(await context.Noticias.ToListAsync());
        }
        catch
        {
            return BadRequest("Erro ao obter as Notícias.");
        }
    }


}