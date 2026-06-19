
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Api.ExceptionsMW;

namespace Dsw2026Ej15.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlerMW>();
            app.MapControllers();
            

            app.Run();

            app.MapHealthChecks("/health-check");
        }
    }
}
