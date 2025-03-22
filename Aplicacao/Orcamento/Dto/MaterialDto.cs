using Orcamento.Enums;

namespace Orcamento.Dto
{
    public class MaterialDto
    {
        public required string Nome { get; set; }

        public string? Formato { get; set; }

        public string? Gramatura { get; set; }

        public required UnidadeEnum idUnidade { get; set; }

        public required decimal Valor { get; set; }


        public required int idStatus { get; set; }
    }
}
