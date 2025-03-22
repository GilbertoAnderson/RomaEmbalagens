using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Orcamento.Dto;
using Orcamento.Models;
using Orcamento.Services.Contato;
using Orcamento.Services.Produto;
using Orcamento.Services.Status;
using Orcamento.Services.Usuario;

namespace Orcamento.Controllers
{
    public class ContatoController : Controller
    {


        private readonly IContatoInterface _contatoInterface;
        private readonly IStatusInterface _statusInterface;

        public ContatoController(IContatoInterface contatoInterface, IStatusInterface statusInterface)
        {
            _contatoInterface = contatoInterface;
            _statusInterface = statusInterface;

        }


        public async Task<IActionResult> Index(string? filtro)
        {


            var contato = await _contatoInterface.GetContato(filtro);
            contato = contato.OrderBy(x => x.Nome).ToList();

            return View(contato);

        }


        public async Task<IActionResult> IndexCliente(int id)
        {

            var contato = await _contatoInterface.GetContatoCliente(id);

            return View(contato);

        }



        // GET: ContatoController/Create
        public async Task<IActionResult> _Create(int id)
        {

            var status = await _statusInterface.GetStatus("CONTATO", "ATIVO");

            ViewBag.IDsTATUS = status.idStatus;
            ViewBag.idCliente = id;
            return View();

        }

        // GET: ContatoController/Create
        public async Task<IActionResult> Create(int id)
        {

            var status = await _statusInterface.GetStatus("CONTATO", "ATIVO");

            ViewBag.idStatus = status.idStatus;
            ViewBag.idCliente = id;

            return View();

        }






        // POST: ContatoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContatoModel _contato)
        {
            if (ModelState.IsValid)
            {

                var contato = await _contatoInterface.Novo(_contato);

                return RedirectToAction("Edit","Cliente", new { id = contato.idCliente });

            }
            else
            {

                return View(_contato);

            }

        }


        // GET: ContatoController1/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var contato = await _contatoInterface.GetContatoId(id);

                var _status = await _statusInterface.GetAllStatus("CONTATO");
                var lst_status = _status.Select(c => new SelectListItem
                {
                    Value = c.idStatus.ToString(),
                    Text = c.Descricao
                });

                ViewBag.Status = lst_status;
                ViewBag.Nome = contato.Nome;

                return View("Edit", contato);
            }
            catch
            {

            }
            return View();


        }

        // POST: ContatoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {

                var _contato = new ContatoModel
                {
                    idContato = contato.idContato,
                    Nome = contato.Nome,
                    Email = contato.Email,
                    Celular = contato.Celular,
                    idCliente = contato.idCliente,
                    idStatus = contato.idStatus,
                    dtNascimento = contato.dtNascimento,
                };

                var contatoSalvo = await _contatoInterface.Salvar(_contato);

                return RedirectToAction("Edit", "Cliente", new { id = contatoSalvo.idCliente });
            }
            else
            {

                return View(contato);
            }


        }




    }
}