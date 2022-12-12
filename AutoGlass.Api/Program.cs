using AutoGlass.Domain.Interfaces.Servicos.Produto;
using AutoGlass.Infra.Persistencia;
using Dominio.Servicos.Produto;
using IoC.Unity;
using Unity;
using Microsoft.EntityFrameworkCore;
using AutoGlass.Domain.Repositorio.Produto;
using AutoGlass.Infra.Persistencia.Repositorios.Produto;
using AutoMapper;
using AutoGlass.Infra.Persistencia.AutoMapper;
using AutoGlass.Domain.Interfaces.Repositorio.Base;
using AutoGlass.Infra.Persistencia.Repositorios.Base;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var sqlConnection = builder.Configuration.GetSection("ConnectionString").Value;
builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(sqlConnection, b => b.MigrationsAssembly("AutoGlass.Api")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IServicoProduto, ServicoProduto>();
builder.Services.AddTransient<IRepositorioProduto, RepositorioProduto>();


builder.Services.AddSingleton(new AutoMapperConfig().Configure().CreateMapper());

var container = new UnityContainer();
DependencyResolver.Resolve(container);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API AutoGlass", Version = "v1" });
});
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();