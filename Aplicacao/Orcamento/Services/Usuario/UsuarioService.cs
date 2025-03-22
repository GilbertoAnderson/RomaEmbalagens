using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Orcamento.Data;
using Orcamento.Enums;
using Orcamento.Models;

namespace Orcamento.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDBContext _context;
        private readonly string _sistema;

        public UsuarioService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }


        public async Task<UsuarioModel> GetUsuarioId(int id)
        {
            try
            {
                return await _context.tblUsuario.FirstOrDefaultAsync(c => c.idUsuario == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<List<UsuarioModel>> GetUsuario(string? filtro)
        {
            try
            {
                if (filtro != null)
                {
                    return await _context.tblUsuario.Where(c => c.Nome.Contains(filtro)).OrderBy(c => c.Nome).ToListAsync();
                }
                else
                {
                    return await _context.tblUsuario.OrderBy(c => c.Nome).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioModel> NovoUsuario(UsuarioModel _usuario)
        {
            try
            {

                _context.Add(_usuario);

                await _context.SaveChangesAsync();

                return _usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<UsuarioModel> Salvar(UsuarioModel usuario)
        {
            try
            {
                var _usuario = await _context.tblUsuario.FirstOrDefaultAsync(c => c.idUsuario == usuario.idUsuario);

                _usuario.Nome = usuario.Nome;
                _usuario.Email = usuario.Email;
                _usuario.Celular = usuario.Celular;
                _usuario.dtNascimento = usuario.dtNascimento;
                _usuario.idStatus = usuario.idStatus;
                _usuario.idPerfil = usuario.idPerfil;
                _usuario.dtAtualizacao = usuario.dtAtualizacao;



                _context.Update(_usuario);

                await _context.SaveChangesAsync();

                return _usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
