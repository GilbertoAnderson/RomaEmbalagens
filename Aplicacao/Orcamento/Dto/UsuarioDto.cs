using System.ComponentModel.DataAnnotations;

namespace Orcamento.Dto
{
    public class UsuarioDto
    {
        [Key]
        public int idUsuario { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


        public string Celular { get; set; } = string.Empty;


        public string Status { get; set; } = string.Empty;
    }
}
