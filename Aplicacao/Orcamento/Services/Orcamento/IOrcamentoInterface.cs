using Orcamento.Models;

namespace Orcamento.Services.Orcamento
{
    public interface IOrcamentoInterface
    {
        Task<OrcamentoModel> GetOrcamentoId(int id);


        Task<List<OrcamentoModel>> GetAllOrcamento(string? filtro);

        Task<List<OrcamentoModel>> GetQtdeOrcamento();

        

    }
}
