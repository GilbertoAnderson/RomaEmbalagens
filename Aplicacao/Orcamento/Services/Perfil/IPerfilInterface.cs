using Orcamento.Models;

namespace Orcamento.Services.Perfil
{
    public interface IPerfilInterface
    {

        Task<PerfilModel> GetPerfilId(int id);
        Task<List<PerfilModel>> GetPerfil();


    }
}
