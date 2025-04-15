using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Orcamento.Data;
using Orcamento.Models;

namespace Orcamento.Services.ProdutoItem
{
    public class ProdutoItemService : IProdutoItemInterface
    {

        private readonly AppDBContext _context;
        private readonly string _sistema;

        public ProdutoItemService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }



        //          Task<List<ProdutoItemModel>> IProdutoItemInterface.GetAllItemProduto(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<ProdutoItemModel>> GetAllItemProduto(int id)
        {
            try
            {
                return await _context.tblProdutoItem.Where(c => c.idProduto == id).ToListAsync();
                //return await _context.tblProdutoItem.Include(i =>i.Item).Where(c => c.idProduto == id).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ProdutoItemModel> GetProdutoItemId(int id)
        {
            try
            {
                return await _context.tblProdutoItem.FirstOrDefaultAsync(c => c.idProdutoItem == id);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<ProdutoItemModel>> GetProdutoItem(string? filtro)
        {
            try
            {

                if (filtro != null)
                {
                    return await _context.tblProdutoItem.Where(c => c.Observacao.Contains(filtro)).ToListAsync();
                }
                else
                {
                    //return await _context.tblProdutoItem.Include(i => i.itensProduto).ToListAsync();
                    return await _context.tblProdutoItem.ToListAsync();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<ProdutoItemModel> Novo(ProdutoItemModel item)
        {
            try
            {

                _context.Add(item);

                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        public async Task<ProdutoItemModel> Salvar(ProdutoItemModel item)
        {
            try
            {

                var _produtoitem = await _context.tblProdutoItem.FirstOrDefaultAsync(c => c.idProdutoItem == item.idProdutoItem);

                _produtoitem.idProduto = item.idProduto;
                _produtoitem.idItem = item.idItem;
                _produtoitem.Observacao = item.Observacao;
                _produtoitem.Valor = item.Valor;
                _produtoitem.idStatus = item.idStatus;
                _produtoitem.Quantidade = item.Quantidade;


                _context.Update(_produtoitem);

                await _context.SaveChangesAsync();

                return _produtoitem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public async Task<ProdutoItemModel> ExcluirItem(ProdutoItemModel Item)
        {
            try
            {
                
                _context.Remove(Item);
                var v = await _context.SaveChangesAsync();

                return Item;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
