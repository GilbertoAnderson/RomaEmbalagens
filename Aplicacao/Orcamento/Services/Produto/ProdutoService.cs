using System.Drawing;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Orcamento.Data;
using Orcamento.Models;

namespace Orcamento.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDBContext _context;
        private readonly string _sistema;

        public ProdutoService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }




        public async Task<ProdutoModel> GetProdutoId(int id)
        {
            try
            {
                return await _context.tblProduto.FirstOrDefaultAsync(c => c.idProduto == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<ProdutoModel>> GetAllProduto(string? filtro)
        {
            try
            {

                if (filtro != null)
                {
                    return await _context.tblProduto.Where(c => c.Nome.Contains(filtro)).OrderBy(c => c.Nome).ToListAsync();
                }
                else
                {
                    return await _context.tblProduto.OrderBy(c => c.Nome).ToListAsync();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<ProdutoModel> Novo(ProdutoModel produto)
        {
            try
            {

                _context.Add(produto);

                await _context.SaveChangesAsync();

                return produto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<ProdutoModel> Salvar(ProdutoModel produto)
        {
            try
            {

                var _produto = await _context.tblProduto.FirstOrDefaultAsync(c => c.idProduto == produto.idProduto);

                _produto.Nome = produto.Nome;
                _produto.dtAtualizacao = produto.dtAtualizacao;
                _produto.Observacao = produto.Observacao;
                _produto.Valor = produto.Valor;
                _produto.idUnidade = produto.idUnidade;
                _produto.idStatus = produto.idStatus;


                _context.Update(_produto);

                await _context.SaveChangesAsync();

                return _produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
