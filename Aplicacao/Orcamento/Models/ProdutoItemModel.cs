using System.ComponentModel.DataAnnotations;

namespace Orcamento.Models
{
    public class ProdutoItemModel
    {
      

        [Key]
        public int idProdutoItem { get; set; }

        public int idProduto { get; set; }

        public int idItem { get; set; }

        public string Nome { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Valor { get; set; }

        public string? Observacao { get; set; }


        public required int idStatus { get; set; }


        //public ItemModel? itensProduto { get; set; }

        //public List<ItemModel>? listaItens { get; set; }



    }
}
