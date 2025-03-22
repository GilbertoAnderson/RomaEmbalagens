using Orcamento.Dto;
using Orcamento.Models;

namespace Orcamento.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<UsuarioModel> GetUsuarioId(int id);

        Task<List<UsuarioModel>> GetUsuario(string? filtro);

        Task<UsuarioModel> NovoUsuario(UsuarioModel usuario);

        Task<UsuarioModel> Salvar(UsuarioModel usuario);

    }
}
