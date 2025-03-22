using Orcamento.Models;

namespace Orcamento.Services.Item
{
    public interface IItemInterface
    {

        Task<ItemModel> GetItemId(int id);


        Task<List<ItemModel>> GetAllItem(string? filtro, int tipo);

        Task<List<ItemModel>> GetItemProduto();


        Task<ItemModel> Novo(ItemModel item);


        Task<ItemModel> Salvar(ItemModel item);

    }
}
