using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Repositories;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Services;
using Wegot.MyLibrary.Api.ApplicationCore.Services;
using Wegot.MyLibrary.Api.Infraestructure.Repositories;
using WeGot.MyLibrary.Api.Infrastructure.Data;

namespace Wegot.MyLibrary.Api
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
            services.AddDbContext<MyLibraryDbContext>(
                          options =>
                              options.UseNpgsql(
                                      Configuration.GetConnectionString("MyLibrary"),
                                      npgsqloption => npgsqloption.CommandTimeout((int)TimeSpan.FromMinutes(60).TotalSeconds)
                                      ),
                          ServiceLifetime.Transient);

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookService, BookService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Library", Version = "v1" });


            }
           );
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "AllowOrigin",
                    builder => {
                        builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowOrigin");
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            //}

            app.UseRouting();


            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
