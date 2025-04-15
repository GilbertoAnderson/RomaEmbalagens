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
using System.Net.NetworkInformation;
using Orcamento.Services.Dominios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Orcamento.Controllers
{
    public class OrcamentoController : Controller
    {

        private readonly IStatusInterface _statusInterface;
        private readonly IClienteInterface _clienteInterface;
        private readonly IOrcamentoInterface _orcamentoInterface;
        private readonly IOrcamentoItemInterface _orcamentoItemInterface;
        private readonly IContatoInterface _contatoInterface;
        private readonly IDominiosInterface _dominioInterface;

        private readonly AppDBContext _context;

        public OrcamentoController( IStatusInterface statusInterface, IClienteInterface clienteInterface,
             IOrcamentoInterface orcamentoInterface, IOrcamentoItemInterface orcamentoItemInterface, 
             IContatoInterface contatoInterface, IDominiosInterface dominioInterface, AppDBContext context)
        {
            _statusInterface = statusInterface;
            _clienteInterface = clienteInterface;
            _orcamentoInterface = orcamentoInterface;
            _orcamentoItemInterface = orcamentoItemInterface;
            _contatoInterface = contatoInterface;
            _dominioInterface = dominioInterface;
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
                    idUsuario = 1,
                    idContato = 1,
                    idFormaPagto = 1,
                    dtCriacao = DateTime.Now,
                    dtValidade = DateTime.Now.AddDays(30)

                };

                var orcamento = await _orcamentoInterface.NovoOrcamento(_orcamentoNovo);

                return RedirectToAction("Edit", new { id = orcamento.idOrcamento, whatsapp= "" });

            }
            else
            {

                return View(_orcamento);
            }

        }



        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(int id, string whatsapp)
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

            var margem = await _dominioInterface.GetDominio("MARGEM");
            var impostos = await _dominioInterface.GetDominio("IMPOSTO");

            decimal _vlrProdutos = 0;   
            foreach (OrcamentoItemModel _orcamentoItem in OrcamentoItem)
            {
                _vlrProdutos = _vlrProdutos + (_orcamentoItem.Quantidade * _orcamentoItem.ValorUnitario) ;
            };


            decimal _percMargem = Convert.ToDecimal(margem.Descricao);
            decimal _percImposto = (decimal)orcamento.percImposto;
            if (orcamento.percImposto == 0)
            {
                _percImposto = Convert.ToDecimal(impostos.Descricao);
            }


            decimal _vlrDesconto = (decimal)orcamento.ValorDesconto;
            decimal _vlrMargem = _vlrProdutos * _percMargem / 100;
            decimal _vlrImposto = (_vlrProdutos + _vlrMargem) * _percImposto / 100;
            decimal _vlrFinal = _vlrProdutos + _vlrMargem + _vlrImposto - _vlrDesconto;

            //.................. remove as casas decimais 
            _vlrProdutos = Math.Round(Convert.ToDecimal(_vlrProdutos.ToString()), 2);
            _vlrImposto = Math.Round(Convert.ToDecimal(_vlrImposto.ToString()), 2);
            _vlrMargem = Math.Round(Convert.ToDecimal(_vlrMargem.ToString()), 2);
            _vlrFinal = Math.Round(Convert.ToDecimal(_vlrFinal.ToString()), 2);


            orcamento.percMargem = _percMargem;
            orcamento.percImposto = _percImposto;

            orcamento.ValorOrcado = _vlrProdutos;
            orcamento.ValorMargem = _vlrMargem;
            orcamento.ValorImposto = _vlrImposto;
            orcamento.ValorFinal = _vlrFinal;


            //.................................... identifca status de orcamentos
            var _status = await _statusInterface.GetAllStatus("ORCAMENTO");
            var lst_status = _status.Select(c => new SelectListItem
            {
                Value = c.idStatus.ToString(),
                Text = c.Descricao
            });





            var contato = await _contatoInterface.GetContatoId(orcamento.idCliente);

            string texto = "";
            texto = texto + "Orcamento: " + orcamento.nrOrcamento + "\r\n";
            texto = texto + cliente.Nome + "\r\n";
            texto = texto + contato.Nome + "\r\n";


            //...................................................................... itens do produto
            texto = texto + "--------------------------- " + "\r\n";
            texto = texto + "Itens " + "\r\n";
            texto = texto + "--------------------------- " + "\r\n";
            texto = texto + " QTDE | DESCRICAO | VALOR " + "\r\n";
            texto = texto + "--------------------------- " + "\r\n";

            foreach (OrcamentoItemModel _orcamentoItem in OrcamentoItem)
            {
                texto = texto + _orcamentoItem.Quantidade.ToString("000,00") + " | " + _orcamentoItem.Nome + " | " + (_orcamentoItem.Quantidade * _orcamentoItem.ValorUnitario) + "\r\n";
            };
            texto = texto + "--------------------------- " + "\r\n";
            texto = texto + "Total Produtos " + orcamento.ValorOrcado.ToString() + "\r\n";
            texto = texto + "Total Desconto " + orcamento.ValorDesconto.ToString() + "\r\n";
            texto = texto + "Valor Final .. " + orcamento.ValorFinal.ToString() + "\r\n";


            //...................................................................... rodape

            texto = texto + "--------------------------- " + "\r\n";
            texto = texto + "Roma Embalagens " + "\r\n";




            ViewBag.FoneContato = contato.Celular;

            ViewBag.Produtos = OrcamentoItem;
            ViewBag.Status = lst_status;
            ViewBag.Nome = cliente.Nome;
            ViewBag.NrOrcamento = orcamento.nrOrcamento;
            ViewBag.idOrcamento = orcamento.idOrcamento;
            ViewBag.Contatos = lst_contatos;
            ViewBag.whatsapp = texto;

            return View(orcamento);



        }


        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Atualizar(OrcamentoModel orcamento)
        {
            var orcamentoSalvo = await _orcamentoInterface.Salvar(orcamento);

            return RedirectToAction("Edit", new { id = orcamento.idOrcamento, whatsapp = "" });
        }

            // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OrcamentoModel orcamento, string idAcao )
        {

            //var _orcamento = new OrcamentoModel
            //{
            //    idCliente = orcamento.idCliente,
            //    idContato = orcamento.idContato,
            //    idStatus = orcamento.idStatus,
            //    idFormaPagto = orcamento.idFormaPagto,
            //    idOrcamento = orcamento.idOrcamento,
            //    idUsuario = 1,
            //    Observacao = orcamento.Observacao,
            //    ValorFinal = orcamento.ValorFinal,
            //    ValorOrcado = orcamento.ValorOrcado,
            //    ValorDesconto = orcamento.ValorDesconto,
            //    dtEntrega = orcamento.dtEntrega

            //};



                var orcamentoSalvo = await _orcamentoInterface.Salvar(orcamento);

            // verificar se o status sé entregue e alterar a dt de entrega
            //var status = await _statusInterface.GetStatus("ORCAMENTO", "Entregue");
            //if (orcamento.idStatus == status.idStatus) {
            //    if (orcamento.dtEntrega == null)
            //    {
            //        _orcamento.dtEntrega = DateTime.Now;
            //    }
            //}

            //if (idAcao == "imprimir")
            //{
            //    return RedirectToAction("imprimir", new { id = orcamentoSalvo.idOrcamento });
            //};

            //if (idAcao == "email")
            //{
            //    return RedirectToAction("email", new { id = orcamentoSalvo.idOrcamento });
            //};

            //if (idAcao == "Atualizar")
            //{
            //    return RedirectToAction("Edit", new { id = orcamento.idOrcamento, whatsapp = "" });
            //};


            return RedirectToAction("Index");
            
        }

        public async Task<ActionResult>  Whatsapp(int id)
        {

            //...................................................................... salava o registro

            var orcamento = await _orcamentoInterface.GetOrcamentoId(id);



            //...................................................................... cabecalho

            var cliente =  await _clienteInterface.GetClienteId(orcamento.idCliente);

            var contato = await _contatoInterface.GetContatoId(orcamento.idCliente);

            var OrcamentoItem = await _orcamentoItemInterface.GetOrcamentoId(orcamento.idOrcamento);

            string texto = "";
            texto = texto + "Orcamento: " + orcamento.nrOrcamento + "\r\n" ;
            texto = texto + cliente.Nome + "\r\n";
            texto = texto + contato.Nome + "\r\n";


            //...................................................................... itens do produto
            texto = texto + "--------------------------- " + "\r\n";
            texto = texto + "Itens " + "\r\n";
            texto = texto + "--------------------------- " + "\r\n";
            texto = texto + " QTDE | DESCRICAO | VALOR " + "\r\n";
            texto = texto + "--------------------------- " + "\r\n";

            foreach (OrcamentoItemModel _orcamentoItem in OrcamentoItem)
            {
                texto = texto + _orcamentoItem.Quantidade.ToString("000,00") + " | " + _orcamentoItem.Nome + " | " +  (_orcamentoItem.Quantidade * _orcamentoItem.ValorUnitario) + "\r\n";
            };
            texto = texto + "--------------------------- " + "\r\n";
            texto = texto + "Total Produtos " + orcamento.ValorOrcado.ToString() + "\r\n";
            texto = texto + "Total Desconto " + orcamento.ValorDesconto.ToString() + "\r\n";
            texto = texto + "Valor Final .. " + orcamento.ValorFinal.ToString() + "\r\n";


            //...................................................................... rodape

            texto = texto + "--------------------------- " + "\r\n";
            texto = texto + "Roma Embalagens " + "\r\n";

            //...................................................................... envia whatsapp



            return RedirectToAction("Edit", new { id = orcamento.idOrcamento, whatsapp = texto });  

        }



        public async Task<ActionResult> CloneOrcamento(int id)
        {


            //............................... define nr do orcamento
            var ls_prefixo = DateTime.Now.ToString("yyMMdd");
            var orcamentos = await _orcamentoInterface.GetQtdeOrcamento();
            int qtde = 1;
            foreach (OrcamentoModel orc in orcamentos)
            {
                qtde++;
            };
            var nrOrcamento = ls_prefixo + qtde.ToString("000");

            //...................................................................... salva o registro

            var status = await _statusInterface.GetStatus("ORCAMENTO", "Elaboracao");

            var orcamento = await _orcamentoInterface.GetOrcamentoId(id);

            var _orcamento = new OrcamentoModel
            {
                idCliente = orcamento.idCliente,
                idContato = orcamento.idContato,
                idFormaPagto = orcamento.idFormaPagto,
                idUsuario = 1,
                Observacao = orcamento.Observacao,
                ValorFinal = orcamento.ValorFinal,
                ValorOrcado = orcamento.ValorOrcado,
                ValorDesconto = orcamento.ValorDesconto,
                idStatus = status.idStatus,
                dtCriacao = DateTime.Now,
                dtValidade = DateTime.Now.AddDays(30)
            };


            var orcamentoSalvo = await _orcamentoInterface.NovoOrcamento(_orcamento);


            //............................................. copiando os itens

            var OrcamentoItem = await _orcamentoItemInterface.GetOrcamentoId(orcamento.idOrcamento);

            int seq = 1;
            foreach (OrcamentoItemModel orcamentoItem in OrcamentoItem)
            {

                var orcamentoItemCopia = new OrcamentoItemModel
                {
                    idOrcamento = orcamentoSalvo.idOrcamento,
                    idProduto = orcamentoItem.idProduto,
                    Sequencial = seq,
                    Nome = orcamentoItem.Nome,
                    Quantidade = orcamentoItem.Quantidade,
                    ValorUnitario = orcamentoItem.ValorUnitario,
                    Observacao = orcamentoItem.Observacao,
                    idUnidade = orcamentoItem.idUnidade
                };
                seq = seq + 1;

                var novoitem = _orcamentoItemInterface.Salvar(orcamentoItemCopia);
            };


            return RedirectToAction("Edit", new { id = orcamentoSalvo.idOrcamento, whatsapp = ""});

        }



    }
}
