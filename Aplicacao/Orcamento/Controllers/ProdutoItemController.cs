using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Orcamento.Dto;
using Orcamento.Models;
using Orcamento.Services.Item;
using Orcamento.Services.Produto;
using Orcamento.Services.ProdutoItem;
using Orcamento.Services.Status;

namespace Orcamento.Controllers
{
    public class ProdutoItemController : Controller
    {


        private readonly IStatusInterface _statusInterface;
        private readonly IProdutoItemInterface _produtoItemInterface;
        private readonly IProdutoInterface _produtoInterface;
        private readonly IItemInterface _itemInterface;



        public ProdutoItemController(IProdutoInterface produtoInterface, IStatusInterface statusInterface, IProdutoItemInterface produtoItemInterface,
            IItemInterface itemInterface)
        {
            _statusInterface = statusInterface;
            _produtoInterface = produtoInterface;
            _produtoItemInterface = produtoItemInterface;
            _itemInterface = itemInterface;

        }



        //// GET: ProdutoItemController
        public async Task<IActionResult> Index(string? filtro)
        {
 
            var produtoItemViewModel = await _produtoItemInterface.GetProdutoItem(filtro);
            
            ////var item = await _itemInterface.GetItemProduto();


            //return View(itensProduto);

            return View(produtoItemViewModel);
        }



        // GET: ContatoController/Create
        public async Task<IActionResult> Create(int id)
        {

            // var status = await _statusInterface.GetStatus("PRODUTOITEM", "ATIVO");
            // ViewBag.idStatus = status.idStatus;

            var item = await _itemInterface.GetItemProduto();

            var lst_Itens = item.Select(c => new SelectListItem
            {
                Value = c.idItem.ToString(),
                Text = c.Nome
            });

            ViewBag.Item = lst_Itens;

            ViewBag.idProduto = id;

            return View();

        }


        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoItemModel _produto)
        {
            if (ModelState.IsValid)
            {
                var status = await _statusInterface.GetStatus("PRODUTOITEM", "ATIVO");

                var _novoProduto = new ProdutoItemModel
                {
                    idItem = _produto.idItem,
                    idProduto = _produto.idProduto,
                    Observacao = _produto.Observacao,
                    idStatus = status.idStatus,
                    Valor = _produto.Valor,
                    Quantidade = _produto.Quantidade
                };


                var produto = await _produtoItemInterface.Novo(_novoProduto);

                return RedirectToAction("Edit", "Produto", new { id = produto.idProduto });
            }
            else
            {

                return View(_produto);
            }

        }



        // GET: ProdutoItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutoItemController/Edit/5
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

        // GET: ProdutoItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutoItemController/Delete/5
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
