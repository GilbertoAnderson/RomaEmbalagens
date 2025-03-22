using Microsoft.EntityFrameworkCore;
using Orcamento.Data;
using Orcamento.Models;

namespace Orcamento.Services.Orcamento
{
    public class OrcamentoService : IOrcamentoInterface
    {

        private readonly AppDBContext _context;
        private readonly string _sistema;

        public OrcamentoService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }


        public async Task<OrcamentoModel> GetOrcamentoId(int id)
        {
            try
            {
                return await _context.tblOrcamento.FirstOrDefaultAsync(c => c.idOrcamento == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<OrcamentoModel>> GetQtdeOrcamento()
        {
            try
            {
                return await _context.tblOrcamento.Where(c => c.dtCriacao.ToString("YYYYMMDD") == DateTime.Now.ToString("YYYYMMDD")).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public async Task<List<OrcamentoModel>> GetAllOrcamento(string? filtro)
        {
            try
            {

                if (filtro != null)
                {
                    //return await _context.tblOrcamento.Where(c => c.Cliente.Nome.Contains(filtro)).OrderBy(c => c.nrOrcamento).ToListAsync();

                    return await _context.tblOrcamento.OrderBy(c => c.nrOrcamento).ToListAsync();
                }
                else
                {
                    //return await _context.tblOrcamento.OrderBy(c => c.nrOrcamento).ToListAsync();

                    //return await _context.tblOrcamento.Include(c => c.Cliente).OrderBy(c => c.nrOrcamento).ToListAsync();
                    //return await _context.tblOrcamento.OrderBy(c => c.nrOrcamento).ToListAsync();
                    var status = _context.tblStatus.FirstOrDefault(s => s.Objeto == "ORCAMENTO" && s.Descricao == "Elaboracao");
                    return await _context.tblOrcamento.Where(c => c.idStatus == status.idStatus).OrderBy(c => c.nrOrcamento).ToListAsync();

                }





            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }
}
