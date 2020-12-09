using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReactAspCoreCrud1.Models;

namespace ReactAspCoreCrud1
{
    public class Startup
    {
        private readonly string MyAllowedSpecificOrigins = "MyAllowedSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // configure db connection
            services.AddDbContext<DonationDBContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection"))
                );
            // configure cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowedSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost",
                            "https://localhost")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // configure cors here
            // app.UseCors(options => options.WithOrigins("https://localhost:5001").AllowAnyHeader().AllowAnyMethod());
            app.UseCors(MyAllowedSpecificOrigins);
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                PrepDB.PrepPopulation(app);
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