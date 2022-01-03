using BL;
using DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace priceTracker
{
    public class Startup//test 2
    {
   
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
    
      
        }
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<PriceTrackerContext>(options => options.UseSqlServer(
            Configuration.GetConnectionString("priceTracker")), ServiceLifetime.Scoped);
            services.AddScoped<ICostumerDl, CostumerDl>();
            services.AddScoped<ICostumerBl, CostumerBl>();
            services.AddScoped<ICompanyDl, CompanyDl>();
            services.AddScoped<ICompanyBl, CompanyBl>();
            services.AddScoped<IPackageBl, PackageBl>();
            services.AddScoped<IPackageDl, PackageDl>();
            services.AddScoped<ICompanyProductBl, CompanyProductBl>();
            services.AddScoped<ICompanyProductDl, CompanyProductDl>();
            services.AddScoped<ICostumerProductBl, CostumerProductBl>();
            services.AddScoped<ICostumerProductDl, CostumerProductDl>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "priceTracker", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("system is up!!");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "priceTracker v1"));
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