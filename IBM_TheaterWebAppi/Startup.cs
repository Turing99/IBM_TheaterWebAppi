using IBM_TheaterWebAppi.Context;
using IBM_TheaterWebAppi.Services.Repositories;
using IBM_TheaterWebAppi.Services.UnitsOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // SS: Represents a set of key/value application configuration properties.
        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            //SS: ConfigureServices is used to add services on the container and to configure those services.
            //SS: All the services we add here can later be injected into other pieces of code that live in our application.

            // Register the DbContext on the container, getting the connection string from appSettings.
            // (Note: Use this during development; In a production environment, it's better to store the connection string in an environment variable)

            var connectionString = Configuration["ConnectionStrings:TheaterDBConnectionString"];
            services.AddDbContext<TheaterContext>(o => o.UseSqlServer(connectionString));

            // SS: Adding services on the container
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITheaterRepository, TheaterRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();


            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.AddScoped<ITheaterUnitOfWork, TheaterUnitOfWork>();
            

        }


            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapGet("/", async context =>
                    {
                        await context.Response.WriteAsync("Hello World!");
                    });
                });
            }
        }
}
