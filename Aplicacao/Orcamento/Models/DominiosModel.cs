using System.ComponentModel.DataAnnotations;

namespace Orcamento.Models
{
    public class DominiosModel
    {
        [Key]
        public int idDominio { get; set; }

        public string? Objeto { get; set; }

        public string? Codigo { get; set; }

        public string? Descricao { get; set; }
    }
}
