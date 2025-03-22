using Orcamento.Models;
using Orcamento.Dto;

namespace Orcamento.Services.Cliente
{
    public interface IClienteInterface
    {

        Task<ClienteModel> GetClienteId(int id);


        Task<List<ClienteModel>> GetCliente(string? filtro);


        //Task<EnderecoDto> PesquisaCEP(string CEP);


        Task<ClienteModel> NovoCliente(ClienteModel cliente);

        Task<ClienteModel> Salvar(ClienteModel cliente);

    }
}
