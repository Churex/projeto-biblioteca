 
 // Exemplo: Models/Livro.cs
namespace BibliotecaApp.Models
{
    public class Emprestimo
{
    public int Id { get; set; } // Chave primária

    public int LivroId { get; set; } // Chave estrangeira para Livro
    public Livro Livro { get; set; } // Propriedade de navegação para Livro

    public int UsuarioId { get; set; } // Chave estrangeira para Usuario
    public Usuario Usuario { get; set; } // Propriedade de navegação para Usuario

    // Outras propriedades, como data do empréstimo, data de devolução, etc.
    public DateTime DataEmprestimo { get; set; }
    public DateTime? DataDevolucao { get; set; }
}

}