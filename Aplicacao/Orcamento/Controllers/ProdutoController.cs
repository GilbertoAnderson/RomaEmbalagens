using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Orcamento.Dto;
using Orcamento.Models;
using Orcamento.Services.Contato;
using Orcamento.Services.Item;
using Orcamento.Services.Produto;
using Orcamento.Services.ProdutoItem;
using Orcamento.Services.Status;

namespace Orcamento.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IStatusInterface _statusInterface;
        private readonly IProdutoInterface _produtoInterface;
        private readonly IProdutoItemInterface _produtoItemInterface;


        /*
        public ProdutoController(IProdutoInterface produtoInterface, IStatusInterface statusInterface)
        {
            _statusInterface = statusInterface;
            _produtoInterface = produtoInterface;

        }
*/
        public ProdutoController(IProdutoInterface produtoInterface, IStatusInterface statusInterface, IProdutoItemInterface produtoItemInterface)
        {
            _statusInterface = statusInterface;
            _produtoInterface = produtoInterface;
            _produtoItemInterface = produtoItemInterface;

        }

        


        //// GET: ProdutoController
        public async Task<IActionResult> Index(string? filtro)
        {


            var produto = await _produtoInterface.GetAllProduto(filtro);


            return View(produto);

        }

       

        // GET: ProdutoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoNovoDto _produto)
        {
            if (ModelState.IsValid)
            {
                var status = await _statusInterface.GetStatus("PRODUTO", "ATIVO");

                var _novoProduto = new ProdutoModel
                {
                    Nome = _produto.Nome,
                    idUnidade = _produto.idUnidade,
                    Observacao= _produto.Observacao,
                    idStatus = status.idStatus,
                    Valor = 0,
                    dtAtualizacao = DateTime.Now
                };

                var produto = await _produtoInterface.Novo(_novoProduto);

                return RedirectToAction("Edit", new { id = produto.idProduto });
            }
            else
            {

                return View(_produto);
            }

        }




        // GET: ProdutoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var produto = await _produtoInterface.GetProdutoId(id);

                var itens = await _produtoItemInterface.GetAllItemProduto(id);

                var _status = await _statusInterface.GetAllStatus("PRODUTO");
                var lst_status = _status.Select(c => new SelectListItem
                {
                    Value = c.idStatus.ToString(),
                    Text = c.Descricao
                });

                ViewBag.idProduto = id;
                ViewBag.Status = lst_status;
                ViewBag.Nome   = produto.Nome;
                ViewBag.Itens = itens;

                return View(produto);
            }
            catch
            {

            }
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProdutoModel _produto)
        {
            if (ModelState.IsValid)
            {

                var _novoProduto = new ProdutoModel
                {
                    idProduto = _produto.idProduto,
                    Nome = _produto.Nome,
                    idUnidade = _produto.idUnidade,
                    Observacao = _produto.Observacao,
                    idStatus = _produto.idStatus,
                    Valor = _produto.Valor,
                    dtAtualizacao = DateTime.Now
                };

                var produto = await _produtoInterface.Salvar(_novoProduto);

                return RedirectToAction("Index");


            }
            else
            {

                return View(_produto);
            }

        }

        


    }
}
