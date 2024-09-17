// Data/BibliotecaContext.cs
using Microsoft.EntityFrameworkCore;
using BibliotecaApp.Models; // Namespace correto para suas entidades

public class BibliotecaContext : DbContext
{
    // Construtor que recebe as opções de contexto
    public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
    {
    }

    // DbSets para suas entidades
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public object Emprestimos { get; internal set; }

    // Configuração adicional opcional
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurações adicionais, como chaves compostas, restrições, etc.
        modelBuilder.Entity<Livro>().Property(l => l.Titulo).IsRequired(); // Exemplo de configuração
        modelBuilder.Entity<Usuario>().Property(u => u.Email).IsRequired();
    }
}
