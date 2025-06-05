using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Template.Application.Interfaces;
using Template.Application.Services;
using Template.Domain.Interfaces;
using Template.Infraestructura.ORM;
using Template.Infraestructure.Repositores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
//builder.Services.AddScoped<IMyDbContext, MyDbContext>();
builder.Services.AddScoped<ICliente, Cliente>();
builder.Services.AddScoped<IMyDbContext>(provider => provider.GetRequiredService<MyDbContext>());

//Conexion a BD
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));


builder.Services.AddHealthChecks().AddCheck("Sql", () =>
{
    using SqlConnection connection = new(builder.Configuration.GetConnectionString("DbConnection"));
    try
    {
        connection.Open();
    }
    catch (Exception ex)
    {
        return HealthCheckResult.Unhealthy(ex.Message);
    }
    try
    {
        SqlCommand migrationsCommand = new("select [MigrationId] from [dbo].[__EFMigrationsHistory]", connection);

        using SqlDataReader reader = migrationsCommand.ExecuteReader();
        List<string> migrationIds = new();
        while (reader.Read())
        {
            string migrationId = reader.GetString(0);
            migrationIds.Add(migrationId);
        }

        connection.Close();
        return HealthCheckResult.Healthy($"Database connected! Found {migrationIds.Count} migration(s): ['{string.Join("', '", migrationIds)}']");
    }
    catch (Exception)
    {
        return HealthCheckResult.Healthy($"Database connected! Table __EFMigrationsHistory not found");
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
