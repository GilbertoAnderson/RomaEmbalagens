using System.ComponentModel.DataAnnotations;
using Orcamento.Enums;

namespace Orcamento.Models
{
    public class UsuarioModel
    {
        [Key]
        public int idUsuario { get; set; }

        public string Nome { get; set; } = string.Empty;    

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public string Celular { get; set; } = string.Empty;

        public DateOnly dtNascimento { get; set; }

        public int idStatus { get; set; }

        public PerfilEnum  idPerfil{ get; set; }

        public DateTime dtAtualizacao { get; set; } 
    }
}
