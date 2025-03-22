using System.ComponentModel.DataAnnotations;

namespace Orcamento.Models
{
    public class OrdemServicoItemModel
    {

        [Key]
        public int idOrdemServicoItem { get; set; }

        public required int idOrdemServico { get; set; }

        public required int idItem { get; set; }

        public required int idStatus { get; set; }


        public required int Sequencial { get; set; }

        public required double Quantidade { get; set; }

        public required int idResponsavel { get; set; }

        public required DateTime dtInicio { get; set; }

        public DateTime? dtTermino { get; set; }

        public required string Observacao { get; set; }

    }
}
