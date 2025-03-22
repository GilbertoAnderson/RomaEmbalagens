using System.ComponentModel.DataAnnotations;

namespace Orcamento.Models
{
    public class PerfilModel
    {
        [Key]
        public int idPerfil { get; set; }

        public required string Descricao { get; set; }

        public required int idStatus { get; set; }
    }
}
