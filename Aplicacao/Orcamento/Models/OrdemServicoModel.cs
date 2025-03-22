using System.ComponentModel.DataAnnotations;

namespace Orcamento.Models
{
    public class OrdemServicoModel
    {

        [Key]
        public int idOrdemServico { get; set; }

        public int idCliente { get; set; }

        public int idUsuario { get; set; }

        public int idStatus { get; set; }

        public string? nrOrdem { get; set; }

        public DateTime dtCriacao { get; set; }

        public DateTime? dtEntrega { get; set; }

        public int Quantidade { get; set; }

        public int idCor { get; set; }

        public string? Observacao { get; set; }

    }
}
