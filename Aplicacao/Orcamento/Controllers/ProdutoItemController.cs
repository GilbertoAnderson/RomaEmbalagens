using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Orcamento.Dto;
using Orcamento.Models;
using Orcamento.Services.Item;
using Orcamento.Services.OrcamentoItem;
using Orcamento.Services.Produto;
using Orcamento.Services.ProdutoItem;
using Orcamento.Services.Status;
using static System.Net.Mime.MediaTypeNames;

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
            

            return View(produtoItemViewModel);
        }



        // GET: ContatoController/Create
        public async Task<IActionResult> Create(int id)
        {

            // var status = await _statusInterface.GetStatus("PRODUTOITEM", "ATIVO");
            // ViewBag.idStatus = status.idStatus;
            var produto = await _produtoInterface.GetProdutoId(id);

            var item = await _itemInterface.GetItemProduto();

            var lst_Itens = item.Select(c => new SelectListItem
            {
                Value =  c.idItem.ToString(),
                Text = c.Nome  + " - " + c.Gramatura + " - " + c.Formato + " | " + c.Valor.ToString()

            });

            ViewBag.Item = lst_Itens;

            ViewBag.NomeProduto = produto.Nome;
            ViewBag.idProduto = id;

            return View();

        }


        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoItemModel _ItemProduto)
        {
            var item = await _itemInterface.GetItemId(_ItemProduto.idItem);
            _ItemProduto.Nome = item.Nome;
            if (item.Gramatura != null)
            {
                _ItemProduto.Nome = item.Nome + " - " + item.Gramatura + " - " + item.Formato;
            }

            if (ModelState.IsValid)
            {
                var status = await _statusInterface.GetStatus("PRODUTOITEM", "ATIVO");

                var _novoItemProduto = new ProdutoItemModel
                {
                    idItem = _ItemProduto.idItem,
                    idProduto = _ItemProduto.idProduto,
                    Observacao = _ItemProduto.Observacao,
                    idStatus = status.idStatus,
                    Valor = _ItemProduto.Valor,
                    Quantidade = _ItemProduto.Quantidade,
                    Nome = _ItemProduto.Nome
                };


                var itemProduto = await _produtoItemInterface.Novo(_novoItemProduto);

                return RedirectToAction("Edit", "Produto", new { id = itemProduto.idProduto });
            }
            else
            {

                return View(_ItemProduto);
            }

        }



        // GET: ProdutoItemController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var item = await _produtoItemInterface.GetProdutoItemId(id);

            var items = await _itemInterface.GetItemProduto();

            var lst_Itens = items.Select(c => new SelectListItem
            {
                Value = c.idItem.ToString(),
                Text = c.Nome + " - " + c.Gramatura + " - " + c.Formato + " | " + c.Valor.ToString()

            });

            var produto = await _produtoInterface.GetProdutoId(item.idProduto);


            var _status = await _statusInterface.GetAllStatus("PRODUTOITEM");
            var lst_status = _status.Select(c => new SelectListItem
            {
                Value = c.idStatus.ToString(),
                Text = c.Descricao
            });

            ViewBag.Status = lst_status;


            @ViewBag.idProduto = item.idProduto;
            @ViewBag.idProdutoItem = item.idProdutoItem;
            ViewBag.Item = lst_Itens;

            ViewBag.NomeProduto = produto.Nome;

            //@ViewBag.Unidade = item.i;

            return View(item);

        }





        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProdutoItemModel _ItemProduto)
        {
            if (ModelState.IsValid)
            {

                var orcamentoItemSalvo = await _produtoItemInterface.Salvar(_ItemProduto);

                return RedirectToAction("Edit", "Produto", new { id = _ItemProduto.idProduto});

            }
            else
            {

                return View(_ItemProduto);
            }
        }





        // GET: OrcamentoItemController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            var item = await _produtoItemInterface.GetProdutoItemId(id);
            int idProduto = item.idProduto;

            await _produtoItemInterface.ExcluirItem(item);


            return RedirectToAction("Edit", "Produto", new { id = idProduto });

        }


    }
}
