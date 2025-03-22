using Microsoft.EntityFrameworkCore;
using Orcamento.Data;
using Orcamento.Models;

namespace Orcamento.Services.Perfil
{
    public class PerfilService : IPerfilInterface
    {

        private readonly AppDBContext _context;
        private readonly string _sistema;

        public PerfilService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }


        public async Task<PerfilModel> GetPerfilId(int id)
        {
            try
            {
                return await _context.tblPerfil.FirstOrDefaultAsync(c => c.idPerfil == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<PerfilModel>> GetPerfil()
        {
            try
            {
                return await _context.tblPerfil.OrderBy(c => c.Descricao).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
