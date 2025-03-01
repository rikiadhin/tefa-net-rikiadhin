using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text;
using backend.Data.Models;
using backend.Data;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container 
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// Fungsi untuk menyiapkan layanan
void ConfigureServices(WebApplicationBuilder builder)
{
    // Menambahkan OpenAPI
    builder.Services.AddOpenApi();
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    // Tambahkan AppDbContext ke DI container
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));

    builder.Services.AddLogging();
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("AllowFrontend",
            policy =>
            {
                policy.WithOrigins("http://localhost:5111")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
    });
    builder.Services.AddControllers(options =>
    {
        options.Filters.Add<RequestTimingInterceptor>();
    });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(
        c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger for Web Api", Version = "v1" });
        // Konfigurasi untuk mengabaikan properti tertentu
        c.IgnoreObsoleteActions();
        c.IgnoreObsoleteProperties();
        c.EnableAnnotations();
    }
    );
}

// Fungsi untuk menyiapkan middleware dan endpoint
void ConfigureApp(WebApplication app)
{
    // Menyediakan dokumentasi API OpenAPI di lingkungan pengembangan
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI(
            c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger for Web Api");
            }
        );
    }
    app.UseCors("AllowFrontend");
    app.UseRouting();
    app.UseHttpsRedirection();
    app.MapControllers();
}

// Memisahkan konfigurasi layanan
ConfigureServices(builder);

// Membangun aplikasi
var app = builder.Build();

// Memisahkan konfigurasi middleware dan endpoint
ConfigureApp(app);

app.Run();
