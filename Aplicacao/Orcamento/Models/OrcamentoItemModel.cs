using System.ComponentModel.DataAnnotations;

namespace Orcamento.Models
{
    public class OrcamentoItemModel
    {
        [Key]
        public int idOrcamentoItem { get; set; }

        public required int idOrcamento { get; set; }

        public required int idProduto { get; set; }

        public required int Sequencial { get; set; }

        public required double Quantidade { get; set; }

        public required double ValorUnitario { get; set; }

        public required string Observacao { get; set; }


    }
}
