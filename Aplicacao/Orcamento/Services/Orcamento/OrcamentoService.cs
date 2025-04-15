using Microsoft.Build.Construction;
using Microsoft.EntityFrameworkCore;
using Orcamento.Data;
using Orcamento.Models;
using Orcamento.Dto;


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
                DateTime hoje = DateTime.Now;
                DateTime amanha = hoje.AddDays(1);

                string _hoje = hoje.ToString("dd-MM-yyyy");
                string _amanha = amanha.ToString("dd-MM-yyyy");
                DateTime inicio = Convert.ToDateTime(_hoje + " 00:00:00");
                DateTime termino = Convert.ToDateTime(_amanha + " 00:00:00");

                return await _context.tblOrcamento.Where(c => c.dtCriacao >= inicio && c.dtCriacao <= termino).ToListAsync();
                //return await _context.tblOrcamento.ToListAsync();
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
                    var lista = _context.tblOrcamento.OrderBy(c => c.nrOrcamento).ToList();
                    return await _context.tblOrcamento.OrderBy(c => c.nrOrcamento).ToListAsync();

                    //return await _context.tblOrcamento.Include(c => c.Cliente).ToListAsync();
                    //return await _context.tblOrcamento.OrderBy(c => c.nrOrcamento).ToListAsync();
                    //var status = _context.tblStatus.FirstOrDefault(s => s.Objeto == "ORCAMENTO" && s.Descricao == "Elaboracao");
                    //return await _context.tblOrcamento.Where(c => c.idStatus == status.idStatus).OrderBy(c => c.nrOrcamento).ToListAsync();
                    
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<OrcamentoModel> NovoOrcamento(OrcamentoModel orcamento)
        {
            try
            {

                _context.Add(orcamento);
                await _context.SaveChangesAsync();

                return orcamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<OrcamentoModel> Salvar(OrcamentoModel orcamento)
        {
            try
            {

                var _orcamento = await _context.tblOrcamento.FirstOrDefaultAsync(c => c.idOrcamento == orcamento.idOrcamento);


                _orcamento.idUsuario = orcamento.idUsuario;

                _orcamento.idCliente = orcamento.idCliente;
                _orcamento.idContato = orcamento.idContato;
                _orcamento.idFormaPagto = orcamento.idFormaPagto;
                _orcamento.idStatus = orcamento.idStatus;
                //_orcamento.nrOrcamento = orcamento.nrOrcamento;
                //_orcamento.dtCriacao = orcamento.dtCriacao;
                _orcamento.dtEnvio = orcamento.dtEnvio;
                _orcamento.dtValidade = orcamento.dtValidade;
                _orcamento.dtEntrega = orcamento.dtEntrega;
                _orcamento.ValorOrcado = orcamento.ValorOrcado;
                _orcamento.ValorDesconto = orcamento.ValorDesconto;
                _orcamento.ValorFinal = orcamento.ValorFinal;
                _orcamento.ValorImposto = orcamento.ValorImposto;
                _orcamento.ValorMargem = orcamento.ValorMargem;
                _orcamento.percImposto = orcamento.percImposto;
                _orcamento.percMargem = orcamento.percMargem;
                _orcamento.Observacao = orcamento.Observacao;


                _context.Update(_orcamento);
                await _context.SaveChangesAsync();

                return orcamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
