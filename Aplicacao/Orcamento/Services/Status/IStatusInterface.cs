using Orcamento.Dto;
using Orcamento.Models;

namespace Orcamento.Services.Status
{
    public interface IStatusInterface
    {
        Task<StatusModel> GetStatusId(int id);

        Task<StatusModel> GetStatus(string? objeto, string? descricao);

        Task<List<StatusModel>> GetAllStatus(string? objeto);

        

    }
}
