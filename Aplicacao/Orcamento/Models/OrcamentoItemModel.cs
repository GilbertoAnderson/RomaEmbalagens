using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Humanizer;

namespace Orcamento.Models
{
    public class OrcamentoItemModel
    {
        [Key]
        public int idOrcamentoItem { get; set; }

        public required int idOrcamento { get; set; }

        public required int idProduto { get; set; }

        public required int idUnidade { get; set; }

        public required int Sequencial { get; set; }

        public required string Nome { get; set; }

        public required decimal Quantidade { get; set; }

        public required decimal ValorUnitario { get; set; }

        public required string Observacao { get; set; }


        //type 'System.Int32' to type 'System.Decimal'.'

        //[NotMapped]
        //public OrcamentoModel Orcamentos { get; set; }

        //[NotMapped]
        //public ProdutoModel Produtos { get; set; }


    }
}
