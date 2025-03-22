using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orcamento.Models;
using Orcamento.Dto;
using Orcamento.Services.Cliente;
using Orcamento.Services.Status;
using Orcamento.Services.Contato;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.NetworkInformation;


namespace Orcamento.Controllers
{
    public class ClienteController : Controller
    {

        private readonly IClienteInterface _clienteInterface;
        private readonly IContatoInterface _contatoInterface;
        private readonly IStatusInterface _statusInterface;

        public ClienteController(IClienteInterface clienteInterface, IStatusInterface statusInterface, IContatoInterface contatoInterface)
        {
            _clienteInterface = clienteInterface;
            _statusInterface = statusInterface;
            _contatoInterface = contatoInterface;

        }


        public async Task<IActionResult> Index(string? filtro)
        {
            //...................

            var cliente = await _clienteInterface.GetCliente(filtro);
            cliente = cliente.OrderBy(x => x.Nome).ToList();

            return View(cliente);

        }


        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteDto _cliente)
        {
            if (ModelState.IsValid)
            {
                var cep = _cliente.CEP;
                var status = await _statusInterface.GetStatus("CLIENTE", "ATIVO");
                //var _endereco = new EnderecoDto;

                //var endereco = new EnderecoDto()
                //{
                //    endereco.Endereco = "Rua Boa vista,  32",
                //    endereco.Bairro = "Camilopolis",
                //    endereco.Cidade = "Santo Andre",
                //    endereco.UF = "SP",
                //    endereco.CEP = _CEP
                //};

                var _clientefull = new ClienteModel
                {
                    Nome = _cliente.Nome,
                    Telefone = _cliente.Telefone,
                    CNPJ = _cliente.CNPJ,

                    Endereco = "",
                    Bairro = "",
                    Cidade = "",
                    UF = "",
                    CEP = _cliente.CEP,
                    idStatus = status.idStatus

                };

                var cliente = await _clienteInterface.NovoCliente(_clientefull);

                return RedirectToAction("Edit", new { id = cliente.IdCliente });

            }
            else 
            {

                return View(_cliente);
            }

        }





        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clienteInterface.GetClienteId(id);
            var contatos = await _contatoInterface.GetContatoCliente(id);

            var _status = await _statusInterface.GetAllStatus("CLIENTE");
            var lst_status = _status.Select(c => new SelectListItem
            {
                Value = c.idStatus.ToString(),
                Text = c.Descricao
            });

            ViewBag.Status = lst_status;
            ViewBag.Nome = cliente.Nome;
            ViewBag.idCliente = cliente.IdCliente;
            ViewBag.Contatos = contatos;

            return View(cliente);
        }


        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {

                var _cliente = new ClienteModel
                {
                    IdCliente = cliente.IdCliente,
                    Nome = cliente.Nome,
                    Telefone = cliente.Telefone,
                    Endereco = cliente.Endereco,
                    Bairro = cliente.Bairro,
                    Cidade = cliente.Cidade,
                    UF = cliente.UF,
                    CEP = cliente.CEP,
                    idStatus = cliente.idStatus
                };

                var clienteSalvo = await _clienteInterface.Salvar(_cliente);

                return RedirectToAction("Index");
            }
            else
            {

                return View(cliente);
            }
        }

    }
}
