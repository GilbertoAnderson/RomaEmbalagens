using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using Orcamento.Dto;
using Orcamento.Models;
using Orcamento.Services.Cliente;
using Orcamento.Services.Contato;
using Orcamento.Services.Orcamento;
using Orcamento.Services.OrcamentoItem;
using Orcamento.Services.Status;
using Orcamento.Data;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using Orcamento.Enums;

namespace Orcamento.Controllers
{
    public class OrcamentoController : Controller
    {

        private readonly IStatusInterface _statusInterface;
        private readonly IClienteInterface _clienteInterface;
        private readonly IOrcamentoInterface _orcamentoInterface;
        private readonly IOrcamentoItemInterface _orcamentoItemInterface;
        private readonly IContatoInterface _contatoInterface;

        private readonly AppDBContext _context;

        public OrcamentoController( IStatusInterface statusInterface, IClienteInterface clienteInterface,
             IOrcamentoInterface orcamentoInterface, IOrcamentoItemInterface orcamentoItemInterface, IContatoInterface contatoInterface, AppDBContext context)
        {
            _statusInterface = statusInterface;
            _clienteInterface = clienteInterface;
            _orcamentoInterface = orcamentoInterface;
            _orcamentoItemInterface = orcamentoItemInterface;
            _contatoInterface = contatoInterface;
            _context = context;

        }


        //// GET: ProdutoController
        public IActionResult Index1(string? filtro)
        {


            List<OrcamentoModel> orcamento = (from orc in _context.tblOrcamento
                                                     join cli in _context.tblCliente on orc.idCliente equals cli.IdCliente
                                                     select orc).ToList();

            // var orcamento = _context.tblOrcamento.Include(c => c.tblCliente).ToList();


            //var orcamento = new OrcamentoModel()
            //{
            //   _context.tblOrcamento.Include(o =>o.Cliente).ToList(),
            //   Cliente = _context.tblCliente.ToList()

            //};

            return View(orcamento);

        }

        //// GET: ProdutoController
        public async Task<ActionResult> Index(string? filtro)
        {

            var orcamento = await _orcamentoInterface.GetAllOrcamento(null);
            //var orcamentoList = new OrcamentoListaDto();
            
            foreach (OrcamentoModel orc in orcamento)
            {
                orc.Status = _context.tblStatus.FirstOrDefault(x => x.idStatus == orc.idStatus);
                orc.Clientes = _context.tblCliente.FirstOrDefault(c => c.IdCliente == orc.idCliente);

                //var item = _context.tblOrcamentoItem.FirstOrDefault(i => i.idOrcamento == orc.idOrcamento);
                //ViewBag.produto[orc.idOrcamento] = item.Produtos.Nome;

            };



            //.................... colocar o filtro aqui
            if (filtro != null)
            { 
            orcamento = orcamento.Where(x => x.Clientes.Nome.Contains(filtro)
                                          || x.Status.Descricao.Contains(filtro)
                                          || x.nrOrcamento.Contains(filtro)).ToList();
            }

            return View(orcamento);

        }



        // GET: OrcamentoController/Create
        public async Task<ActionResult> Create()
        {
            //............................... define nr do orcamento
            var ls_prefixo = DateTime.Now.ToString("yyMMdd");
            var orcamentos = await _orcamentoInterface.GetQtdeOrcamento();
            int qtde = 1;
            foreach(OrcamentoModel orcamento in orcamentos)
            {
                qtde++;
            };
            var nrOrcamento = ls_prefixo + qtde.ToString("000") ;


            var cliente = await _clienteInterface.GetCliente(null);
            var lst_cliente= cliente.Select(c => new SelectListItem
            {
                Value = c.IdCliente.ToString(),
                Text = c.Nome
            });

            ViewBag.NrOrcamento = nrOrcamento ;
            ViewBag.Cliente = lst_cliente;

            return View();
        }


        // POST: OrcamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrcamentoDto _orcamento)
        {
            if (ModelState.IsValid)
            {

                var status = await _statusInterface.GetStatus("ORCAMENTO", "Elaboracao");


                var _orcamentoNovo = new OrcamentoModel
                {
                    nrOrcamento = _orcamento.nrOrcamento,
                    idCliente = _orcamento.idCliente,
                    idStatus = status.idStatus,
                    dtCriacao = DateTime.Now,
                    dtValidade = DateTime.Now.AddDays(30)

                };

                //  var cliente = await _clienteInterface.NovoCliente(_orcamentoNovo);

                return RedirectToAction("Edit", new { id = _orcamentoNovo.idOrcamento });

            }
            else
            {

                return View(_orcamento);
            }

        }



        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var orcamento = await _orcamentoInterface.GetOrcamentoId(id);

            var cliente = await _clienteInterface.GetClienteId(orcamento.idCliente);

            var contatos = await _contatoInterface.GetContatoCliente(orcamento.idCliente);
            var lst_contatos = contatos.Select(c => new SelectListItem
            {
                Value = c.idContato.ToString(),
                Text = c.Nome
            });

            var OrcamentoItem = await _orcamentoItemInterface.GetOrcamentoId(orcamento.idOrcamento);

            //.................................... calcula valor orcado
            decimal _vlrProdutos = 0;   
            foreach (OrcamentoItemModel _orcamentoItem in OrcamentoItem)
            {
                _vlrProdutos = _vlrProdutos + (_orcamentoItem.Quantidade * _orcamentoItem.ValorUnitario) ;
            };

            orcamento.ValorOrcado = _vlrProdutos;
            orcamento.ValorFinal = _vlrProdutos - orcamento.ValorDesconto;


            //.................................... identifca status de orcamentos
            var _status = await _statusInterface.GetAllStatus("ORCAMENTO");
            var lst_status = _status.Select(c => new SelectListItem
            {
                Value = c.idStatus.ToString(),
                Text = c.Descricao
            });



            ViewBag.Produtos = OrcamentoItem;

            ViewBag.Status = lst_status;
            ViewBag.Nome = cliente.Nome;
            ViewBag.NrOrcamento = orcamento.nrOrcamento;
            ViewBag.idOrcamento = orcamento.idOrcamento;
            ViewBag.Contatos = lst_contatos;


            return View(orcamento);



        }


        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OrcamentoModel orcamento)
        {

            var _orcamento = new OrcamentoModel
            {
                idCliente = orcamento.idCliente,
                idContato = orcamento.idContato,
                idStatus = orcamento.idStatus,
                idFormaPagto = orcamento.idFormaPagto,
                idOrcamento = orcamento.idOrcamento,
                idUsuario = 1,
                Observacao = orcamento.Observacao,
                ValorFinal = orcamento.ValorFinal,
                ValorOrcado = orcamento.ValorOrcado,
                ValorDesconto = orcamento.ValorDesconto,
                dtEntrega = orcamento.dtEntrega

            };



                var orcamentoSalvo = await _orcamentoInterface.Salvar(_orcamento);

                // verificar se o status sé entregue e alterar a dt de entrega
                //var status = await _statusInterface.GetStatus("ORCAMENTO", "Entregue");
                //if (orcamento.idStatus == status.idStatus) {
                //    if (orcamento.dtEntrega == null)
                //    {
                //        _orcamento.dtEntrega = DateTime.Now;
                //    }
                //}




                return RedirectToAction("Index");
            
        }


    }
}
