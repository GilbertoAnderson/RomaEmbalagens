using Microsoft.EntityFrameworkCore;
using Orcamento.Services.Status;
using Orcamento.Services.Dominios;
using Orcamento.Services.Perfil;
using Orcamento.Services.Usuario;
using Orcamento.Services.Contato;
using Orcamento.Services.Item;
using Orcamento.Services.OrcamentoItem;
using Orcamento.Services.Orcamento;
using Orcamento.Services.OrdemServico;
using Orcamento.Services.OrdemServicoItem;
using Orcamento.Services.Cliente;
using Orcamento.Services.Produto;
using Orcamento.Services.ProdutoItem;
using Orcamento.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IStatusInterface, StatusService>();
builder.Services.AddScoped<IDominiosInterface, DominiosService>();
builder.Services.AddScoped<IPerfilInterface, PerfilService>();
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();
builder.Services.AddScoped<IContatoInterface, ContatoService>();
builder.Services.AddScoped<IItemInterface, ItemService>();
builder.Services.AddScoped<IOrcamentoItemInterface, OrcamentoItemService>();
builder.Services.AddScoped<IOrcamentoInterface, OrcamentoService>();
builder.Services.AddScoped<IOrdemServicoInterface, OrdemServicoService>();
builder.Services.AddScoped<IOrdemServicoItemInterface, OrdemServicoItemService>();
builder.Services.AddScoped<IClienteInterface, ClienteService>();
builder.Services.AddScoped<IProdutoInterface, ProdutoService>();
builder.Services.AddScoped<IProdutoItemInterface, ProdutoItemService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
