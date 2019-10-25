using BrainShark.Api.Services.Database;
using BrainShark.Api.Services.Health;
using BrainShark.Api.Services.Info;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Reflection;

namespace Api
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
            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            });

            services.AddCors();

            services.AddDatabaseService(Configuration.GetConnectionString("Default")).AddInfoService().AddHealthService();

            // Register the Swagger services
            services.AddSwaggerDocument(o=> {
                o.Title = ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
                o.Version = ((AssemblyFileVersionAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false)[0]).Version;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

           // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c=>c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseStatusCodePages();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

        }
    }
}
