using System.ComponentModel.DataAnnotations;

namespace Orcamento.Dto
{
    public class StatusDto
    {
        [Key]
        public int idStatus { get; set; }

        public required string Descricao { get; set; }
    }
}
