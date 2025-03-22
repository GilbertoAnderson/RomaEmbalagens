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
using Orcamento.Services.Status;
using Orcamento.Data;
using Microsoft.EntityFrameworkCore;

namespace Orcamento.Controllers
{
    public class OrcamentoController : Controller
    {

        private readonly IStatusInterface _statusInterface;
        private readonly IClienteInterface _clienteInterface;
        private readonly IOrcamentoInterface _orcamentoInterface;

        private readonly AppDBContext _context;

        public OrcamentoController( IStatusInterface statusInterface, IClienteInterface clienteInterface, IOrcamentoInterface orcamentoInterface, AppDBContext context)
        {
            _statusInterface = statusInterface;
            _clienteInterface = clienteInterface;
            _orcamentoInterface = orcamentoInterface;
            _context = context;

        }


        //// GET: ProdutoController
        public IActionResult Index1(string? filtro)
        {


            List<Models.OrcamentoModel> orcamento = (from orc in _context.tblOrcamento
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


            var orcamento = await _orcamentoInterface.GetAllOrcamento(filtro);

            return View(orcamento);

        }



        // GET: OrcamentoController/Create
        public async Task<ActionResult> Create()
        {
            //............................... define nr do orcamento
            var ls_prefixo = DateTime.Now.ToString("YYMMDD");
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


       //// POST: OrcamentoController/Create
       //[HttpPost]
       //[ValidateAntiForgeryToken]
       // public async Task<IActionResult> Create(OrcamentoDto _orcamento)
       // {
       //     if (ModelState.IsValid)
       //     {

       //         var status = await _statusInterface.GetStatus("ORCAMENTO", "Elaboracao");


       //         var _orcamentoNovo = new OrcamentoModel
       //         {
       //             nrOrcamento= _orcamento.nrOrcamento,
       //             idCliente= _orcamento.idCliente,
       //             idStatus = status.idStatus,
       //             dtCriacao = DateTime.Now    

       //         };

       //       //  var cliente = await _clienteInterface.NovoCliente(_orcamentoNovo);

       //         return RedirectToAction("Edit", new { id = _orcamentoNovo.idOrcamento });

       //     }
       //     else
       //     {

       //         return View(_orcamento);
       //     }

       // }













        //// POST: OrcamentoController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: OrcamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrcamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrcamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrcamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
