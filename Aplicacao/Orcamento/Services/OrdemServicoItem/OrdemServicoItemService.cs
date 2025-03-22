using Microsoft.EntityFrameworkCore;
using Orcamento.Data;
using Orcamento.Models;

namespace Orcamento.Services.OrdemServicoItem
{

    public class OrdemServicoItemService : IOrdemServicoItemInterface
    {

        private readonly AppDBContext _context;
        private readonly string _sistema;

        public OrdemServicoItemService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }


        public async Task<List<OrdemServicoItemModel>> GetOrdemServicoItemId(int id)
        {
            try
            {
                return await _context.tblOrdemServicoItem.Where(c => c.idOrdemServicoItem == id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<List<OrdemServicoItemModel>> GetOrdemServicoItem(string? filtro)
        {
            try
            {
                return await _context.tblOrdemServicoItem.Where(c => c.Observacao == filtro).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
