using API_Sistema.Model.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Sistema.Business;
using API_Sistema.Business.Implementation;
using API_Sistema.Repository;
using API_Sistema.Repository.Implementation;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace API_Sistema
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

            services.AddControllers();

            var connection = Configuration["SQLConnection:SQLConnectionString"];

            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<SQLContext>(options => options.UseSqlServer(connection));

            //Dependency Injection
            services.AddScoped<IUsuarioBusiness, UsuarioBusinessImplementation>();
            services.AddScoped<IUsuarioRepository, UsuarioRepositoryImplementation>();

            services.AddScoped<IProdutoBusiness, ProdutoBusinessImplementation>();
            services.AddScoped<IProdutoRepository, ProdutoRepositoryImplementation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
