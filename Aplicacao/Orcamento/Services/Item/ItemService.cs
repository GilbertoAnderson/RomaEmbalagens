
using Microsoft.EntityFrameworkCore;
using Orcamento.Data;
using Orcamento.Models;

namespace Orcamento.Services.Item
{
    public class ItemService : IItemInterface
    {



        private readonly AppDBContext _context;
        private readonly string _sistema;

        public ItemService(AppDBContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;

        }


        public async Task<ItemModel> GetItemId(int id)
        {
            try
            {
                return await _context.tblItem.FirstOrDefaultAsync(c => c.idItem == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public async Task<List<ItemModel>> GetItemProduto()
        {
            try
            {

                var status = _context.tblStatus.FirstOrDefault(s => s.Objeto == "ITEM" && s.Descricao == "ATIVO");
                return await _context.tblItem.Where(c => c.idStatus == status.idStatus).OrderBy(c => c.Nome).ToListAsync();
               

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<ItemModel>> GetAllItem(string? filtro, int tipo)
        {
            try
            {

                if (filtro != null)
                {
                    return await _context.tblItem.Where(c => c.idTipoItem == tipo
                                                          && c.Nome.Contains(filtro)).OrderBy(x => x.Nome).ToListAsync();
                }
                else
                {
                    var status = _context.tblStatus.FirstOrDefault(s => s.Objeto == "ITEM" && s.Descricao == "ATIVO");
                    return await _context.tblItem.Where(c => c.idTipoItem == tipo && c.idStatus == status.idStatus).OrderBy(x => x.Nome).ToListAsync();
                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<ItemModel> Novo(ItemModel item)
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


        public async Task<ItemModel> Salvar(ItemModel item)
        {
            try
            {

                var _item = await _context.tblItem.FirstOrDefaultAsync(c => c.idItem == item.idItem);

                _item.Nome = item.Nome;
                _item.idTipoItem = item.idTipoItem;
                _item.dtAtualizacao = item.dtAtualizacao;
                _item.Valor = item.Valor;
                _item.idUnidade = item.idUnidade;
                _item.idStatus = item.idStatus;
                _item.Gramatura = item.Gramatura;
                _item.Formato = item.Formato;


                _context.Update(_item);

                await _context.SaveChangesAsync();

                return _item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
