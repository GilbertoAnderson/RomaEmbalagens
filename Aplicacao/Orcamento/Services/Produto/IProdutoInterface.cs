using Orcamento.Models;

namespace Orcamento.Services.Produto
{
    public interface IProdutoInterface
    {
        Task<ProdutoModel> GetProdutoId(int id);


        Task<List<ProdutoModel>> GetAllProduto(string? filtro);


        Task<ProdutoModel> Novo(ProdutoModel item);

        Task<ProdutoModel> Salvar(ProdutoModel item);



    }
}

