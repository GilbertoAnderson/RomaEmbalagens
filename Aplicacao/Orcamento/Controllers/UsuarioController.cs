using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orcamento.Dto;
using Orcamento.Models;
using Orcamento.Services.Cliente;
using Orcamento.Services.Dominios;
using Orcamento.Services.Perfil;
using Orcamento.Services.Status;
using Orcamento.Services.Usuario;

namespace Orcamento.Controllers
{
    public class UsuarioController : Controller
    {


        private readonly IUsuarioInterface _usuarioInterface;
        private readonly IStatusInterface _statusInterface;
       // private readonly IDominiosInterface _dominioInterface;
        private readonly IPerfilInterface _perfilInterface;

        

        public UsuarioController(IUsuarioInterface usuarioInterface, IStatusInterface statusInterface, IPerfilInterface IPerfilInterface)
        {
            _statusInterface = statusInterface;
            _usuarioInterface = usuarioInterface;
            _perfilInterface = IPerfilInterface;

        }


        public async Task<IActionResult> Index(string? filtro)
        {


            var usuario = await _usuarioInterface.GetUsuario(filtro);
            usuario = usuario.OrderBy(x => x.Nome).ToList();

            return View(usuario);

        }



        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(UsuarioModel _usuario)
        {
            if (ModelState.IsValid)
            { 
                var  status = await _statusInterface.GetStatus("USUARIO", "ATIVO");
                var ls_year = DateTime.Now.Year;


                string celular = _usuario.Celular;
                celular = celular.Replace(" ", "");
                if (celular.Length > 2)
                {
                    string prefixo = celular.Substring(0, 2);
                    string numero = celular.Substring(2, 8);
                    celular = prefixo + " " + numero;
                }


                var _Newusuario = new UsuarioModel
                {
                    Nome = _usuario.Nome,
                    Email = _usuario.Email,
                    Celular = celular,
                    idPerfil = _usuario.idPerfil,
                    idStatus = status.idStatus,
                    dtAtualizacao = DateTime.Now,
                    Senha = "Roma@"+ ls_year

                };

                var usuario = await _usuarioInterface.NovoUsuario(_Newusuario);

                return RedirectToAction("Index");
            }
            else
            {

                return View(_usuario);
            }

        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var usuario = await _usuarioInterface.GetUsuarioId(id);

                var _status = await _statusInterface.GetAllStatus("USUARIO");
                var lst_status = _status.Select(c => new SelectListItem
                                          {
                                              Value = c.idStatus.ToString(),
                                              Text = c.Descricao
                                          });

                ViewBag.Status = lst_status;    
                ViewBag.NomeUsuario = usuario.Nome;

                return View(usuario);
            }
            catch
            {
                 
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(UsuarioModel _usuario)
        {
            if (ModelState.IsValid)
            {

                string celular = _usuario.Celular;
                celular = celular.Replace(" ", "");
                if (celular.Length > 2)
                {
                    string prefixo  = celular.Substring(0, 2);
                    string numero = celular.Substring(2, 8);
                    celular = prefixo + " " + numero;
                }

                var _Newusuario = new UsuarioModel
                {
                    idUsuario = _usuario.idUsuario,
                    Nome = _usuario.Nome,
                    Email = _usuario.Email,
                    Celular = celular,
                    idPerfil = _usuario.idPerfil,
                    idStatus = _usuario.idStatus,
                    dtNascimento = _usuario.dtNascimento,
                    dtAtualizacao = DateTime.Now

                };

                var usuario = await _usuarioInterface.Salvar(_Newusuario);

                return RedirectToAction("Index");
            }
            else
            {

                return View(_usuario);
            }

        }

    }
}
