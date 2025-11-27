using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace WebApplication1_Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            /*.net >=5 */
            var webapplicationbuilder = WebApplication.CreateBuilder(args);
            /*//don't need to startup class   start from .Net 6.0*/
            #region how to  configure services :
            //services
            webapplicationbuilder.Services.AddControllersWithViews(); 
            #endregion

            var app=webapplicationbuilder.Build();

            #region configure
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            #region new syntax
            app.MapGet("/", async context =>
               {
                   await context.Response.WriteAsync("Hello World!");
               });
            #endregion

            #region old syntax 
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //}); 
            #endregion 
            #endregion
            app.Run();


        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
