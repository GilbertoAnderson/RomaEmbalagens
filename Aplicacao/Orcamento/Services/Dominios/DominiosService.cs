using Orcamento.Data;
using Orcamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Orcamento.Services.Dominios
{
    public class DominiosService : IDominiosInterface
    {
        private readonly AppDBContext _context;
        private readonly string _sistema;

        public DominiosService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }


        public async Task<DominiosModel> GetDominioId(int id)
        {
            try
            {
                return await _context.tblDominios.FirstOrDefaultAsync(c => c.idDominio == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<DominiosModel>> GetDominiosObjeto(string objeto)
        {
            try
            {
                return await _context.tblDominios.Where(c => c.Objeto == objeto).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<DominiosModel> GetDominio(string objeto)
        {
            try
            {
                return await _context.tblDominios.FirstOrDefaultAsync(c => c.Objeto == objeto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
