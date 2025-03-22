using Microsoft.EntityFrameworkCore;
using Orcamento.Data;
using Orcamento.Models;

namespace Orcamento.Services.OrdemServico
{
    public class OrdemServicoService : IOrdemServicoInterface
    {
        private readonly AppDBContext _context;
        private readonly string _sistema;

        public OrdemServicoService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }


        public async Task<List<OrdemServicoModel>> GetOrdemServicoId(int id)
        {
            try
            {
                return await _context.tblOrdemServico.Where(c => c.idOrdemServico == id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<List<OrdemServicoModel>> GetOrdemServico(string? filtro)
        {
            try
            {
                return await _context.tblOrdemServico.Where(c => c.Observacao == filtro).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
