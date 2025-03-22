using Orcamento.Models;

namespace Orcamento.Services.Dominios
{
    public interface IDominiosInterface
    {
        Task<DominiosModel> GetDominioId(int id);

        Task<List<DominiosModel>> GetDominiosObjeto(string objeto);
    }
}
