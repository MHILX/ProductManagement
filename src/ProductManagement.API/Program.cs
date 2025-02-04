
using ProductManagement.App.Services;
using ProductManagement.Core.Interfaces;
using ProductManagement.Infra.Repositories;

namespace ProductManagement.API
{
    public sealed partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi(); // Document name is v1
            builder.Services.AddOpenApi("internal"); // Document name is internal

            builder.Services.AddScoped<IProductRepo, ProductRepo>(); // Register IProductRepo with its implementation
            builder.Services.AddScoped<ProductService>(); // Register ProductService

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi("/openapi/v1/openapi.json");
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1/openapi.json", "v1");
                    options.RoutePrefix = "swagger"; // Set the Swagger UI at the root URL
                    options.DocumentTitle = "Product Management API Documentation"; // Set the document title
                    options.DisplayRequestDuration(); // Display request duration
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
