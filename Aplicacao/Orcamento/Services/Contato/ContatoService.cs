using Microsoft.EntityFrameworkCore;
using Orcamento.Data;
using Orcamento.Dto;
using Orcamento.Models;


namespace Orcamento.Services.Contato
{
    public class ContatoService : IContatoInterface
    {


        private readonly AppDBContext _context;
        private readonly string _sistema;

        public ContatoService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }


        public async Task<ContatoModel> GetContatoId(int id)
        {

            try
            {
                return await _context.tblContato.FirstOrDefaultAsync(c =>c.idContato == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<List<ContatoModel>> GetContato(string? filtro)
        {

            try
            {
                if (filtro != null)
                {
                    return await _context.tblContato.Where(c => c.Nome.Contains(filtro)
                                                             || c.Email.Contains(filtro)
                    ).OrderBy(c => c.Nome).ToListAsync();
                }
                else
                {
                    var status = _context.tblStatus.FirstOrDefault(s => s.Objeto == "CONTATO" && s.Descricao == "ATIVO");
                    return await _context.tblContato.Where(c => c.idStatus == status.idStatus).OrderBy(c => c.Nome).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        public async Task<List<ContatoModel>> GetContatoCliente(int idCliente)
        {

            try
            {
                var status = _context.tblStatus.FirstOrDefault(s => s.Objeto == "CONTATO" && s.Descricao == "ATIVO");
                return await _context.tblContato.Where(c => c.idCliente == idCliente && c.idStatus == status.idStatus).OrderBy(c => c.Nome).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }





        public async Task<ContatoModel> Novo(ContatoModel contato)
        {
            try
            {

                _context.Add(contato);
                await _context.SaveChangesAsync();

                return contato;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<ContatoModel> Salvar(ContatoModel contato)
        {
            try
            {

                var _contato = await _context.tblContato.FirstOrDefaultAsync(c => c.idContato == contato.idContato);

                _contato.Nome = contato.Nome;
                _contato.idStatus = contato.idStatus;
                _contato.dtNascimento = contato.dtNascimento;
                _contato.Email = contato.Email;
                _contato.Celular = contato.Celular;


                _context.Update(_contato);

                await _context.SaveChangesAsync();

                return _contato;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
