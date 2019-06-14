using Dev.Ui.Site.Data;
using Dev.Ui.Site.Servicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dev.Ui.Site {
    public class Startup {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {

            services.Configure<RazorViewEngineOptions>(options => {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            services.AddDbContext<MeuDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MeuDbContext")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.AddTransient<IOperacaoTransient, Operacao>();
            services.AddScoped<IOperacaoScoped, Operacao>();
            services.AddSingleton<IOperacaoSingleton, Operacao>();
            services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));

            services.AddTransient<OperacaoService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Home}/{Action=Index}/{id?}");

                //routes.MapRoute("areas", "{area=exists}/{controller=Home}/{Action=Index}/{id?}");
                routes.MapAreaRoute(name: "AreaProdutos", areaName: "Produtos", template: "Produtos/{controller=Cadastro}/{Action=Index}/{id?}");
                routes.MapAreaRoute(name: "AreaVendas", areaName: "Vendas", template: "Vendas/{controller=Pedidos}/{Action=Index}/{id?}");
            });
        }
    }
}
