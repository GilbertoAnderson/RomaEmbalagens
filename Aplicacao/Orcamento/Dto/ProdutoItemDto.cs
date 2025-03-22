namespace Orcamento.Dto
{
    public class ProdutoItemDto
    {


        public int idProdutoItem { get; set; }

        public int idProduto { get; set; }

        public int idItem { get; set; }

        public string? Nome { get; set; }

        public decimal? Quantidade { get; set; }

        public decimal? Valor { get; set; }

    }
}
