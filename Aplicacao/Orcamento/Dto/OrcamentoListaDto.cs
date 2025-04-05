namespace Orcamento.Dto
{
    public class OrcamentoListaDto
    {

        public int idOrcamento { get; set; }

        public int idCliente { get; set; }

        public int? idStatus { get; set; }

        public string? nrOrcamento { get; set; }

        public string? Cliente { get; set; }

        public string? Status { get; set; }


        public DateTime dtCriacao { get; set; }

    }
}
