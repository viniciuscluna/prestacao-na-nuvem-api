﻿using PrestacaoNuvem.Api.Domain.Interfacesk;
using System.Diagnostics.CodeAnalysis;

namespace PrestacaoNuvem.Api.Infrastructure.Configurations.DependecyInjectionConfig;
[ExcludeFromCodeCoverage]
public static class DependecyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
       
        #region Injection Repository
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IPrestadorRepository, PrestadorRepository>();
        services.AddScoped<IVeiculoRepository, VeiculoRepository>();
        services.AddScoped<IPrestacaoServicoRepository, PrestacaoServicoRepository>();
        services.AddScoped<ICategoriaServicoRepository, CategoriaServicoRepository>();
        services.AddScoped<ISubServicoRepository, SubServicoRepository>();
        services.AddScoped<IServicoRepository, ServicoRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IFuncionarioPrestadorRepository, FuncionarioPrestadorServiceRepository>();
        services.AddScoped<IDashboardRepository, DashboardRepository>();
        services.AddScoped<IFilialRepository, FilialRepository>();
        #endregion

        #region Injection Services
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IFuncionarioService, FuncionarioService>();
        services.AddScoped<IPrestacaoServicoService, PrestacaoServicoService>();
        services.AddScoped<IPrestadorService, PrestadorService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<ISubCategoriaServicoService, SubCategoriaServicoService>();
        services.AddScoped<IVeiculoService, VeiculoService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IEmailManager, EmailManager>();
        services.AddScoped<IFilialService, FilialService>();
        #endregion

        #region Cors
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:5173", "https://oficina-nuvem.vercel.app", "https://mercado-nuvem.vercel.app");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });
        });
        #endregion

        #region Json
        services.AddControllers().AddJsonOptions(cfg =>
        {
            cfg.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            cfg.JsonSerializerOptions.MaxDepth = 0;
        });
        #endregion

        #region Fluent
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        #endregion
    }
}
