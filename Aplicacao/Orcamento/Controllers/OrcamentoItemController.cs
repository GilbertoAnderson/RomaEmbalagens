using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Orcamento.Dto;
using Orcamento.Models;
using Orcamento.Services.Contato;
using Orcamento.Services.Orcamento;
using Orcamento.Services.OrcamentoItem;
using Orcamento.Services.Produto;
using Orcamento.Services.Status;

namespace Orcamento.Controllers
{
    public class OrcamentoItemController : Controller
    {

        private readonly IOrcamentoItemInterface _orcamentoItemInterface;
        private readonly IProdutoInterface _produtoInterface;
        private readonly IStatusInterface _statusInterface;

        public OrcamentoItemController(IOrcamentoItemInterface orcamentoItemInterface, IStatusInterface statusInterface, IProdutoInterface produtoInterface)
        {
            _orcamentoItemInterface = orcamentoItemInterface;
            _statusInterface = statusInterface;
            _produtoInterface = produtoInterface;

        }


        public async Task<IActionResult> Index(int id)
        {

            var itens = await _orcamentoItemInterface.GetOrcamentoId(id);

            return View(itens);

        }

        // GET: ContatoController/Create
        public async Task<IActionResult> Create(int id)
        {

            ViewBag.idOrcamento = id;

            return View();

        }


        // POST: OrcamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrcamentoItemModel _orcamentoItem)
        {
            if (ModelState.IsValid)
            {

                var orcamentoItemSalvo = await _orcamentoItemInterface.Salvar(_orcamentoItem);

                return RedirectToAction("Edit", "Orcamento", new { id = orcamentoItemSalvo.idOrcamento });

            }
            else
            {

                return View(_orcamentoItem);
            }

        }



        // GET: ContatoController/Clonar
        public async Task<IActionResult> Clonar(int id)
        {

            //var status = await _statusInterface.GetStatus("CONTATO", "ATIVO");
            var produtos = await _produtoInterface.GetAllProduto(null);
            var lst_produtos = produtos.Select(c => new SelectListItem
            {
                Value = c.idProduto.ToString(),
                Text = c.Nome
            });

            ViewBag.ProdutoModelo = lst_produtos;
            ViewBag.idOrcamento = id;

            return View();

        }


        // POST: OrcamentoItemController/Clonar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Clonar(int idProduto, int idOrcamento)
        {
            try
            {

                 var _produto = await _produtoInterface.GetProdutoId(idProduto);

                var _orcamentoItem = new OrcamentoItemModel
                {
                    idOrcamento = idOrcamento,
                    idProduto = idProduto,
                    Sequencial = 1,
                    Nome= _produto.Nome,
                    Quantidade =1,
                    ValorUnitario= _produto.Valor,
                    Observacao = _produto.Observacao,
                    idUnidade = _produto.idUnidade
                };

                var orcamentoItemSalvo = await _orcamentoItemInterface.ClonarProduto(_orcamentoItem);

                return RedirectToAction("Edit", new { id = orcamentoItemSalvo.idOrcamentoItem});
            }
            catch
            {
                return RedirectToAction(nameof(Create)); ;
            }
        }



        // GET: OrcamentoItemController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var orcamentoItem = await _orcamentoItemInterface.GetOrcamentoItemId(id);


            @ViewBag.idOrcamento = orcamentoItem.idOrcamento;

            @ViewBag.Unidade = orcamentoItem.idUnidade;

            return View(orcamentoItem);

        }



        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OrcamentoItemModel _orcamentoItem)
        {
            if (ModelState.IsValid)
            {

                var orcamentoItemSalvo = await _orcamentoItemInterface.Salvar(_orcamentoItem);

                return RedirectToAction("Edit", "Orcamento", new { id = _orcamentoItem.idOrcamento });

            }
            else
            {

                return View(_orcamentoItem);
            }
        }



        // GET: OrcamentoItemController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            var orcamentoItem = await _orcamentoItemInterface.GetOrcamentoItemId(id);
            await _orcamentoItemInterface.ExcluirItem(orcamentoItem);


            return RedirectToAction("Edit", "Orcamento", new { id = orcamentoItem.idOrcamento });

        }





    }
}
