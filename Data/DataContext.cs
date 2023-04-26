using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    public DbSet<Leitor> Leitores { get; set; } = null!;

    public DbSet<Autor> Autores { get; set; } = null!;

    public DbSet<Noticia> Noticias { get; set; } = null!;

    public DbSet<Comentario> Comentarios { get; set; } = null!;
}