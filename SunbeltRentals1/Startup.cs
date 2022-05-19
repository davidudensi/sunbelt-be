using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SunbeltRentals1.Data;
using SunbeltRentals1.MockData;
using SunbeltRentals1.Models;
using SunbeltRentals1.Services;

namespace SunbeltRentals1
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
            services.AddDbContextPool<SunbeltDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SunbeltConnectionString")));
            //services.AddSingleton<IPerson, PersonService>();
            services.AddScoped<IPerson, PersonService>();
            services.AddScoped<IParty, PartyService>();
            services.AddScoped<IDrink, DrinkService>();
            services.AddScoped<IAttendee, AttendeeService>();

            services.AddCors();
            //services.AddMvc(option => option.EnableEndpointRouting = false);
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(
                options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            );

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
