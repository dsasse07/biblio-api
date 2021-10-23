using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblioApi.Data;
using BiblioApi.Repositories;
using BiblioApi.Services;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Npgsql;

namespace BiblioApi
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
      // // Enable CORS
      services.AddCors(c =>
      {
        c.AddPolicy(
            "AllowOrigin",
            options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
        );
      });

      // Establishes connection from app to database using information from appSettings.json
      var connectionBuilder = new NpgsqlConnectionStringBuilder
      (
          Configuration.GetConnectionString("LocalConnection")
      );
      // Get DB password from user secrets
      connectionBuilder.Password = Configuration["LocalDb:Password"];
      services.AddDbContext<DataContext>(p => p.UseNpgsql(
              connectionBuilder.ConnectionString
          ));

      // Added Newtonsoft for PATCH
      services.AddControllers().AddNewtonsoftJson(s =>
      {
        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        s.SerializerSettings.Formatting = Formatting.Indented;
      });

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "BiblioApi", Version = "v1" });
      });

      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      // Associates the interface to a specific class implmentation.
      // This dependency injection method allows us to easily swap out the implementation of the interface
      // AddSigleton = Same instance for every single request
      // AddScoped = New instance per client request
      // Transient = New instance for every use

      // Repositories
      services.AddScoped<IBooksRepository, BooksRepository>();
      services.AddScoped<IUsersRepository, UsersRepository>();
      services.AddScoped<IUserBooksRepository, UserBooksRepository>();

      // Services
      services.AddScoped<IUsersService, UsersService>();
      services.AddScoped<IBooksService, BooksService>();
      services.AddScoped<IUserBooksService, UserBooksService>();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      // Enable Cors
      app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BiblioApi v1"));
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
