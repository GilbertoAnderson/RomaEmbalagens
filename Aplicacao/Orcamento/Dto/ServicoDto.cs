using Orcamento.Enums;

namespace Orcamento.Dto
{
    public class ServicoDto
    {

        public required string Nome { get; set; }

        public required UnidadeEnum idUnidade { get; set; }

        public required decimal Valor { get; set; }

        public required int idStatus { get; set; }

    }
}
