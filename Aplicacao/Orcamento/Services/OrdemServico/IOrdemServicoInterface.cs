using Orcamento.Models;

namespace Orcamento.Services.OrdemServico
{
    public interface IOrdemServicoInterface
    {
        Task<List<OrdemServicoModel>> GetOrdemServicoId(int id);


        Task<List<OrdemServicoModel>> GetOrdemServico(string? filtro);
    }
}
