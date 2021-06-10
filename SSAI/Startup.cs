using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SSAI.Data;
using SSAI.Entity.IRepository;
using SSAI.Entity.Repository;
using SSAI.Helpers;
using SSAI.Helpers.Authorize;
using SSAI.Service;
using SSAI.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SSAIDBOrderContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionOrder")));

            services.AddDbContext<SSAIDBProductContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionProduct")));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            services.AddScoped<IUnitOfWorkOrder, UnitOfWorkOrder>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWorkProduct, UnitOfWorkProduct>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
