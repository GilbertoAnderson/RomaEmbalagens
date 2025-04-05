using Orcamento.Models;

namespace Orcamento.Services.OrcamentoItem
{
    public interface IOrcamentoItemInterface
    {
        Task<OrcamentoItemModel> GetOrcamentoItemId(int id);


        Task<List<OrcamentoItemModel>> GetOrcamentoId(int id);


        Task<List<OrcamentoItemModel>> GetOrcamentoItem(string? filtro);

        Task<OrcamentoItemModel> ClonarProduto(OrcamentoItemModel orcamentoItem);

        Task<OrcamentoItemModel> Salvar(OrcamentoItemModel orcamentoItem);


        Task<OrcamentoItemModel> ExcluirItem(OrcamentoItemModel orcamentoItem);

        

    }
}
