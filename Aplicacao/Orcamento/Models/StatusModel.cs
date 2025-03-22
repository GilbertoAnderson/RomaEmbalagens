using System.ComponentModel.DataAnnotations;

namespace Orcamento.Models
{
    public class StatusModel
    {
        [Key]
        public int idStatus { get; set; }

        public required string Objeto { get; set; } 

        public required string Descricao { get; set; }

    }
}
