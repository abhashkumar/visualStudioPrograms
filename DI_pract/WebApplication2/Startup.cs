using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2
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
            //DbFIle db = new DbFIle();
            //services.AddSingleton<ExampleLogger>(provider => db);
            //services.AddSingleton<DbSpecific>(provider => db);
            services.AddSingleton<ExampleLogger, FlatFile>();
            services.AddSingleton<DbSpecific, DbFIle>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication2", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    #region WAY-1 (Autofac Module)

        //    // Add modules registrations.

        //   // builder.RegisterModule(new MyAutofacModule());
        //    //builder.RegisterModule(new MyAutofacModule2());
        //    //builder.RegisterModule(new MyAutofacModule3());

        //    #endregion

        //    #region WAY-2 (Direct Registration)

        //    // Add services registrations.

        //    builder.RegisterType<DbFIle>().As<ExampleLogger>().SingleInstance();
        //    builder.RegisterType<DbFIle>().As<DbSpecific>().SingleInstance();

        //    #endregion
        //}
    }
}
