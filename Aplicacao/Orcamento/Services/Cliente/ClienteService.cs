using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
using Orcamento.Data;
using Orcamento.Dto;
using Orcamento.Models;
using Orcamento.Services.Status;

namespace Orcamento.Services.Cliente
{
    public class ClienteService : IClienteInterface 
    {

        private readonly AppDBContext _context;
        private readonly string _sistema;
        //private readonly IStatusInterface _statusInterface;

        public ClienteService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }



        public async Task<ClienteModel> GetClienteId(int id)
        {
            try
            {
                return await _context.tblCliente.FirstOrDefaultAsync(c => c.IdCliente == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<List<ClienteListDto>> GetCliente(string? filtro)
        {
            try
            {
                if (filtro != null)
                {
                    return await _context.tblCliente.Where(c => c.Nome.Contains(filtro)
                                                             || c.Bairro.Contains(filtro)
                                                             || c.Cidade.Contains(filtro)
                    ).OrderBy(c => c.Nome).ToListAsync();
                }
                else
                {
                    var status = _context.tblStatus.FirstOrDefault(s => s.Objeto == "CLIENTE" && s.Descricao == "ATIVO");
                    return await _context.tblCliente.Where(c => c.idStatus == status.idStatus).OrderBy(c => c.Nome).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public Task<EnderecoDto> PesquisaCEP(string _CEP)
        //{
        //    try
        //    {
        //        var endereco = new EnderecoDto() {
        //            endereco.Endereco = "Rua Boa vista,  32",
        //            endereco.Bairro = "Camilopolis",
        //            endereco.Cidade = "Santo Andre",
        //            endereco.UF = "SP",
        //            endereco.CEP = _CEP};

        //        return endereco;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<ClienteModel> NovoCliente(ClienteModel cliente)
        {
            try 
            {

                _context.Add(cliente);  
                await _context.SaveChangesAsync();

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }



        public async Task<ClienteModel> Salvar(ClienteModel cliente)
        {
            try
            {

                var _cliente = await _context.tblCliente.FirstOrDefaultAsync(c => c.IdCliente == cliente.IdCliente);

                _cliente.IdCliente = cliente.IdCliente;
                _cliente.Nome = cliente.Nome;
                _cliente.Telefone = cliente.Telefone;
                _cliente.Endereco = cliente.Endereco;
                _cliente.Bairro = cliente.Bairro;
                _cliente.Cidade = cliente.Cidade;
                _cliente.UF = cliente.UF;
                _cliente.CEP = cliente.CEP;
                _cliente.idStatus = cliente.idStatus;


                _context.Update(_cliente);
                await _context.SaveChangesAsync();

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
