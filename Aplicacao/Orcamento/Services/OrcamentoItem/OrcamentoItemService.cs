using Microsoft.EntityFrameworkCore;
using Orcamento.Data;
using Orcamento.Models;

namespace Orcamento.Services.OrcamentoItem
{
    public class OrcamentoItemService : IOrcamentoItemInterface
    {

        private readonly AppDBContext _context;
        private readonly string _sistema;

        public OrcamentoItemService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }



        public async Task<OrcamentoItemModel> GetOrcamentoItemId(int id)
        {
            try
            {
                return await _context.tblOrcamentoItem.FirstOrDefaultAsync(c => c.idOrcamentoItem == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<OrcamentoItemModel>> GetOrcamentoId(int id)
        {
            try
            {
                return await _context.tblOrcamentoItem.Where(c => c.idOrcamento == id).OrderBy(c =>c.Sequencial).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<OrcamentoItemModel>> GetOrcamentoItem(string? filtro)
        {
            try
            {
                return await _context.tblOrcamentoItem.Where(c => c.Observacao == filtro).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public async Task<OrcamentoItemModel> ClonarProduto(OrcamentoItemModel orcamentoItem)
        {
            try
            {

                _context.Add(orcamentoItem);
                await _context.SaveChangesAsync();

                return orcamentoItem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<OrcamentoItemModel> Salvar(OrcamentoItemModel orcamentoItem)
        {
            try
            {

                _context.Update(orcamentoItem);
                await _context.SaveChangesAsync();

                return orcamentoItem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        public async Task<OrcamentoItemModel> ExcluirItem(OrcamentoItemModel orcamentoItem)
        {
            try
            {
                //var orcamentoItem =  await _context.tblOrcamentoItem.FirstOrDefaultAsync(c => c.idOrcamentoItem == id);

                _context.Remove(orcamentoItem);
                var v = await _context.SaveChangesAsync();

                return orcamentoItem;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }




    }
}
