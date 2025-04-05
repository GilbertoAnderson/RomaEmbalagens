using Orcamento.Models;
using Orcamento.Dto;

namespace Orcamento.Services.Orcamento
{
    public interface IOrcamentoInterface
    {
        Task<OrcamentoModel> GetOrcamentoId(int id);


        Task<List<OrcamentoModel>> GetAllOrcamento(string? filtro);

        //Task<List<OrcamentoListaDto>> GetListOrcamento();


        Task<List<OrcamentoModel>> GetQtdeOrcamento();


        Task<OrcamentoModel> Salvar(OrcamentoModel orcamento);

    }
}
