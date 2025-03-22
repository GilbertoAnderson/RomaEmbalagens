using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orcamento.Services.Item;
using Orcamento.Services.Status;
using Orcamento.Enums;
using Orcamento.Models;
using Orcamento.Services.Usuario;
using Orcamento.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Orcamento.Controllers
{
    public class ItemController : Controller
    {

        private readonly IStatusInterface _statusInterface;
        private readonly IItemInterface _itemInterface;



        public ItemController(IItemInterface itemInterface, IStatusInterface statusInterface)
        {
            _statusInterface = statusInterface;
            _itemInterface = itemInterface;

        }


        public async Task<IActionResult> IndexMaterial(string? filtro)
        {

            var tipo = (int)Enums.ItemEnum.Material;

            var item = await _itemInterface.GetAllItem(filtro, tipo);


            return View(item);

        }

        public async Task<IActionResult> IndexServico(string? filtro)
        {

            var tipo = (int)Enums.ItemEnum.Serviço;

            var item = await _itemInterface.GetAllItem(filtro, tipo);

            return View(item);

        }


        // GET: UsuarioController/Create
        public ActionResult CreateServico()
        {

            return View();

        }


        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateServico(ServicoDto _item)
        {
            if (ModelState.IsValid)
            {
                var status = await _statusInterface.GetStatus("ITEM", "ATIVO");
                var idTipo = (int)Enums.ItemEnum.Serviço;

                var _NewItem = new ItemModel
                {
                    Nome = _item.Nome,
                    Valor = _item.Valor,
                    idUnidade = _item.idUnidade,
                    idStatus = status.idStatus,
                    idTipoItem = idTipo,
                    Gramatura ="",
                    Formato="",
                    dtAtualizacao = DateTime.Now
                };

                var item = await _itemInterface.Novo(_NewItem);

                return RedirectToAction("IndexServico");
            }
            else
            {

                return View(_item);
            }

        }



        // GET: ItemController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var item = await _itemInterface.GetItemId(id);

                var _status = await _statusInterface.GetAllStatus("ITEM");
                var lst_status = _status.Select(c => new SelectListItem
                {
                    Value = c.idStatus.ToString(),
                    Text = c.Descricao
                });

                ViewBag.Status = lst_status;
                ViewBag.NomeItem = item.Nome;
                if (item.idTipoItem == 1) 
                {
                    ViewBag.Index = "IndexServico";
                 }
                else
                {
                    ViewBag.Index = "IndexMaterial";
                }

                return View(item);
            }
            catch
            {

            }
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ItemModel _item)
        {
            if (ModelState.IsValid)
            {

                var _NewItem = new ItemModel
                {
                    idItem = _item.idItem,
                    Nome = _item.Nome,
                    Valor = _item.Valor,
                    idUnidade = _item.idUnidade,
                    idStatus = _item.idStatus,
                    idTipoItem = _item.idTipoItem,
                    Gramatura = _item.Gramatura,
                    Formato = _item.Formato,
                    dtAtualizacao = DateTime.Now
                };

                var item = await _itemInterface.Salvar(_NewItem);

                if (item.idTipoItem == 1)
                {
                    return RedirectToAction("IndexServico");
                }
                else
                {
                    return RedirectToAction("IndexMaterial");
                }


            }
            else
            {

                return View(_item);
            }

        }








        //.................................................................................................................... material


        // GET: UsuarioController/Create
        public ActionResult CreateMaterial()
        {

            return View();

        }


        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMaterial(MaterialDto _item)
        {
            if (ModelState.IsValid)
            {
                var status = await _statusInterface.GetStatus("ITEM", "ATIVO");
                var idTipo = (int)Enums.ItemEnum.Material;

                var _NewItem = new ItemModel
                {
                    Nome = _item.Nome,
                    Valor = _item.Valor,
                    idUnidade = _item.idUnidade,
                    idStatus = status.idStatus,
                    idTipoItem = idTipo,
                    Gramatura = _item.Gramatura,
                    Formato = _item.Formato,
                    dtAtualizacao = DateTime.Now
                };

                var item = await _itemInterface.Novo(_NewItem);

                return RedirectToAction("IndexMaterial");
            }
            else
            {

                return View(_item);
            }

        }


    }
}
