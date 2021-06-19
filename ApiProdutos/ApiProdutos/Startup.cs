using ApiProdutos.Data.MySQL;
using ApiProdutos.Data.Repositories;
using ApiProdutos.Data.Repositories.Generic;
using ApiProdutos.Domain.Services;
using ApiProdutos.Domain.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiProdutos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Para a conexão com o DB
            string mySqlConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<MySQLContext>(options =>
                    options.UseMySql(mySqlConnection,
                        ServerVersion.AutoDetect(mySqlConnection)));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiProdutos", Version = "v1" });
            });

            // Injetando as dependências
            services.AddScoped<IProdutoService, ProdutoServiceImpl>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiProdutos v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
