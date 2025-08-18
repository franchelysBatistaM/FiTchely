using ActividadesDeportivas.Api.Settings;
using ActividadesDeportivas.Application.Contracts;
using ActividadesDeportivas.Application.Services;
using ActividadesDeportivas.Infrastructure.Context;
using ActividadesDeportivas.Infrastructure.Interfaces;
using ActividadesDeportivas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ActividadesDeportivas.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configuración Fitbit
            builder.Services.Configure<FitbitSettings>(
                builder.Configuration.GetSection("Fitbit"));

            builder.Services.AddHttpClient();

            // Configuración de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazor",
                    policy =>
                    {
                        policy.WithOrigins(
                            "https://localhost:7225",
                            "http://localhost:5221" 
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            builder.Services.AddDbContext<ActividadesDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ActividadeDeportivaDb")));

            builder.Services.AddScoped<IUsuarioDeportivoRepository, UsuarioDeportivoRepository>();
            builder.Services.AddScoped<IActividadRepository, ActividadRepository>();
            builder.Services.AddScoped<IEstadisticaProgresoRepository, EstadisticaProgresoRepository>();
            builder.Services.AddScoped<IResumenFitbitRepository, ResumenFitbitRepository>();


            builder.Services.AddScoped<IUsuarioDeportivoService, UsuarioDeportivoService>();
            builder.Services.AddScoped<IActividadFisicaService, ActividadFisicaService>();
            builder.Services.AddScoped<IEstadisticaProgresoService, EstadisticaProgresoService>();
            builder.Services.AddScoped<IResumenFitbitService, ResumenFitbitService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowBlazor");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
