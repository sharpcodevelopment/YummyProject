
using FluentValidation;
using Microsoft.OpenApi.Models;
using System.Reflection;
using YummyProject.API.Context;
using YummyProject.API.Entities.Models;
using YummyProject.API.ValidationRules;

namespace YummyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // DbContext eklendi
            builder.Services.AddDbContext<ApiContext>();
            // AutoMapper'ý eklendi
            builder.Services.AddAutoMapper(x => 
            x.AddMaps(Assembly.GetExecutingAssembly()));

            
            // FluentValidation eklendi
            builder.Services.AddScoped<IValidator<Product>, ProductValidation>();


            // Servisleri ekle
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "YummyProject API", Version = "v1" });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "YummyProject API v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
