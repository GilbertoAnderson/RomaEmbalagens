using System.ComponentModel.DataAnnotations;

namespace Orcamento.Models
{
    public class ContatoModel
    {
        [Key]
        public int idContato { get; set; }

        public int idCliente { get; set; }

        public required string Nome { get; set; }

        public string? Celular { get; set; }

        public required string Email { get; set; }

        public DateOnly? dtNascimento { get; set; }

        public required int idStatus { get; set; }

    }
}
