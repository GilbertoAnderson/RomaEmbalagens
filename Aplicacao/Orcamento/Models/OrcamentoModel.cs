using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Orcamento.Models
{
    public class OrcamentoModel
    {
        [Key]
        public int idOrcamento { get; set; }

        public int? idContato { get; set; }


        public int idUsuario { get; set; }

        public int? idFormaPagto { get; set; }

        public int? idStatus { get; set; }

        public string? nrOrcamento { get; set; }

        public DateTime dtCriacao { get; set; }

        public DateTime? dtEnvio { get; set; }

        public DateTime? dtValidade { get; set; }

        public DateTime? dtEntrega { get; set; }

        public decimal? percMargem { get; set; }
        public decimal? percImposto { get; set; }
        public decimal? ValorMargem { get; set; }
        public decimal? ValorImposto { get; set; }
        public decimal? ValorOrcado { get; set; }

        public decimal? ValorDesconto { get; set; }

        public decimal? ValorFinal { get; set; }

        public string? Observacao { get; set; }

        public int idCliente { get; set; }

        [NotMapped]
        public virtual ClienteModel Clientes { get; set; }


        [NotMapped]
        public StatusModel Status { get; set; }


        [NotMapped]
        public OrcamentoItemModel OrcamentoItens { get; set; }


        //public List<ClienteModel> listaCliente { get; set; }

        //public List<StatusModel> listaStatus { get; set; }

    }
}
