using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A_Knights_Tail.Repositories;
using A_Knights_Tail.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace A_Knights_Tail
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
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "A_Knights_Tail", Version = "v1" });
         });

         services.AddCors(options =>
                   {
                      options.AddPolicy("CorsDevPolicy", builder =>
                          {
                             builder
                                      .WithOrigins(new string[]{
                            "http://localhost:8080",
                            "http://localhost:8081"
                                      })
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials();
                          });
                   });

         services.AddTransient<CastlesService>();
         services.AddTransient<CastlesRepository>();
         services.AddTransient<KnightsService>();
         services.AddTransient<KnightsRepository>();

         services.AddScoped<IDbConnection>(x => CreateDbConnection());
      }

      private IDbConnection CreateDbConnection()
      {
         string connectionString = Configuration["db:gearhost"];
         return new MySqlConnector.MySqlConnection(connectionString);
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "A_Knights_Tail v1"));
         }

         app.UseCors("CorsDevPolicy");

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
