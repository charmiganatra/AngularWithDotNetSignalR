using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bloodgrpsignal.hub;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 
namespace bloodgrp_signal
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
            services.AddCors();
            services.AddMvc();
            services.AddSignalR().AddAzureSignalR("Endpoint=https://test.service.signalr.net;AccessKey=eXxh4F2zgk9kYFVlLVVZUnMG9/ny+SosrRreUJ8SPd4=;");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCors(builder =>
          builder.WithOrigins("http://localhost:61404", "http://bloodgroupsampleapp.azurewebsites.net", "http://localhost:4200", "http://192.168.10.235:4200", "https://bloodgroupsignalr.azurewebsites.net", "http://bloodgroupsignalr.azurewebsites.net")
              .AllowCredentials()
              .AllowAnyHeader()
              .AllowAnyMethod());

            app.UseFileServer();
            app.UseAzureSignalR(routes =>
            {
                routes.MapHub<Bloodgrouphub>("/bloodgrphub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
