using System.ComponentModel.DataAnnotations;
using Orcamento.Enums;

namespace Orcamento.Models
{
    public class ItemModel
    {
        [Key]
        public int idItem { get; set; }

        public required int idTipoItem { get; set; }

        public required string Nome { get; set; }

        public string? Formato { get; set; }

        public string? Gramatura { get; set; }

        public required UnidadeEnum idUnidade { get; set; }

        public required decimal Valor { get; set; }

        public required DateTime dtAtualizacao { get; set; }

        public required int idStatus { get; set; }


    }
}
