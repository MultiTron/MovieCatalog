using MCApplicationServices.Implementations;
using MCApplicationServices.Interfaces;
using MCData.Context;
using MCRepositories.Implementations;
using MCRepositories.Interfaces;
using MCWebWCF.Implementations;
using MCWebWCF.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .WriteTo.Console()
    .CreateLogger();
try
{
    Log.Information("Application is starting.....");

    var connectionString = configuration.GetConnectionString("DefaultConnectionString");
    builder.Services.AddDbContext<MovieCatalogDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MCWebWCF")));

    builder.Services.AddServiceModelServices();
    builder.Services.AddServiceModelMetadata();
    builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
    builder.Services.AddScoped<DbContext, MovieCatalogDbContext>();
    builder.Services.AddScoped<IGenreRepository, GenreRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IGenreManagementService, GenreManagementService>();

    builder.Services.AddSerilog();

    var app = builder.Build();

    app.UseServiceModel(serviceBuilder =>
    {
        serviceBuilder.AddService<Service>();
        serviceBuilder.AddServiceEndpoint<Service, IService>(new BasicHttpBinding(), "/Service.svc");
        serviceBuilder.AddService<GenresService>();
        serviceBuilder.AddServiceEndpoint<GenresService, IGenresService>(new BasicHttpBinding(), "/GenresService.svc");
        var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
        serviceMetadataBehavior.HttpGetEnabled = true;
    });

    app.Run();
}
catch (Exception ex)
{
    throw new Exception(ex.Message);
}
finally
{
    await Log.CloseAndFlushAsync();
}