using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using SampleMVCDevexApp.Models;

namespace SampleMVCDevexApp
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
            //W zrobi³ du¿o zmian ...
            // Add framework services.
            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services
                .AddDbContext<SamplemvcContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"), op => op.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink(); //W_doda³
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseHsts(); //W_usun¹³
            }
            //app.UseHttpsRedirection(); //W_usun¹³
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); //W_doda³
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                //endpoints.MapHub<DispatcherHub>("/DispatcherHub");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
