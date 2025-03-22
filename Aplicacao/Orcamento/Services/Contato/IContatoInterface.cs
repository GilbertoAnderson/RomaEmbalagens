using Orcamento.Dto;
using Orcamento.Models;

namespace Orcamento.Services.Contato
{
    public interface IContatoInterface
    {

        Task<ContatoModel> GetContatoId(int id);


        Task<List<ContatoModel>> GetContato(string? filtro);


        Task<List<ContatoModel>> GetContatoCliente(int id);

        
        Task<ContatoModel> Novo(ContatoModel contato);


        Task<ContatoModel> Salvar(ContatoModel contato);

    }

}
