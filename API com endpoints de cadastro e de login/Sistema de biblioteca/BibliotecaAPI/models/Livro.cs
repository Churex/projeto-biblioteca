// Exemplo: Models/Livro.cs
namespace BibliotecaApp.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Genero { get; set; }
        public int QuantidadeDisponivel { get; set; }
    }
}
