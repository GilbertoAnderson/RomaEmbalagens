using Orcamento.Data;
using Orcamento.Models;
using Orcamento.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Orcamento.Services.Status
{
    public class StatusService : IStatusInterface
    {
        private readonly AppDBContext _context;
        private readonly string _sistema;

        public StatusService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }


        public async Task<StatusModel> GetStatusId(int id)
        {
            try
            {
                return await _context.tblStatus.Where(c => c.idStatus == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<StatusModel> GetStatus(string objeto, string descricao)
        {
            try
            {
#pragma warning disable CS8603 // Possível retorno de referência nula.
                return await _context.tblStatus.FirstOrDefaultAsync(c => c.Objeto == objeto && c.Descricao == descricao);
#pragma warning restore CS8603 // Possível retorno de referência nula.

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StatusModel>> GetAllStatus(string objeto)
        {
            try
            {

                return await _context.tblStatus.Where(x => x.Objeto == objeto).OrderBy(x => x.Descricao).ToListAsync();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

