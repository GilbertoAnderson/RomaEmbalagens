using Orcamento.Models;

namespace Orcamento.Services.OrcamentoItem
{
    public interface IOrcamentoItemInterface
    {
        Task<List<OrcamentoItemModel>> GetOrcamentoItemId(int id);


        Task<List<OrcamentoItemModel>> GetOrcamentoItem(string? filtro);
    }
}
