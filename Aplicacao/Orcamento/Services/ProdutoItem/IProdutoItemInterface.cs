using Orcamento.Models;

namespace Orcamento.Services.ProdutoItem
{
    public interface IProdutoItemInterface
    {
        Task<ProdutoItemModel> GetProdutoItemId(int id);

        Task<List<ProdutoItemModel>> GetAllItemProduto(int id);


        Task<List<ProdutoItemModel>> GetProdutoItem(string? filtro);


        Task<ProdutoItemModel> Novo(ProdutoItemModel item);

        Task<ProdutoItemModel> Salvar(ProdutoItemModel item);


        Task<ProdutoItemModel> ExcluirItem(ProdutoItemModel item);
        

    }
}
