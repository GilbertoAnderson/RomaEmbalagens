using Microsoft.EntityFrameworkCore;
using Orcamento.Models;

namespace Orcamento.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        
        public DbSet<ClienteModel> tblCliente { get; set; }
        public DbSet<ContatoModel> tblContato { get; set; }
        public DbSet<DominiosModel> tblDominios { get; set; }
        public DbSet<ItemModel> tblItem { get; set; }
        public DbSet<OrcamentoItemModel> tblOrcamentoItem { get; set; }
        public DbSet<OrcamentoModel> tblOrcamento { get; set; }
        public DbSet<OrdemServicoModel> tblOrdemServico { get; set; }
        public DbSet<OrdemServicoItemModel> tblOrdemServicoItem { get; set; }
        public DbSet<PerfilModel> tblPerfil { get; set; }
        public DbSet<ProdutoItemModel> tblProdutoItem { get; set; }
        public DbSet<ProdutoModel> tblProduto { get; set; }
        public DbSet<StatusModel> tblStatus { get; set; }
        public DbSet<UsuarioModel> tblUsuario { get; set; }

    }
}
