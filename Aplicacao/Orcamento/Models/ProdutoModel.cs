using System.ComponentModel.DataAnnotations;

namespace Orcamento.Models
{
    public class ProdutoModel
    {
        [Key]
        public int idProduto { get; set; }
        public required string Nome { get; set; } = string.Empty;
        public required int idUnidade { get; set; }
        public required decimal Valor { get; set; }
        public required string Observacao { get; set; }
        public required DateTime dtAtualizacao { get; set; }
        public required int idStatus { get; set; }


    }
}
