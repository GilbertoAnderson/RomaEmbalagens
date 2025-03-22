using Orcamento.Models;

namespace Orcamento.Services.OrdemServicoItem
{
    public interface IOrdemServicoItemInterface
    {
        Task<List<OrdemServicoItemModel>> GetOrdemServicoItemId(int id);


        Task<List<OrdemServicoItemModel>> GetOrdemServicoItem(string? filtro);

    }
}
