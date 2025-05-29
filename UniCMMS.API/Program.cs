using Microsoft.EntityFrameworkCore;
using Serilog;
using UniCMMS.Application.Interfaces;
using UniCMMS.Application.Services;
using UniCMMS.Domain.Interfaces;
using UniCMMS.Infrastructure.Persistence;
using UniCMMS.Infrastructure.Repositories;
using UniCMMS.API.Middleware; 

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog (optionnel)
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();

// Ajout DbContext avec SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enregistrement des repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();

// Enregistrement des services métiers
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWorkOrderService, WorkOrderService>();

// Ajout des controllers
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware gestion des erreurs
app.UseMiddleware<ErrorHandlingMiddleware>();

// Swagger en développement
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Important : mapper les controllers
app.MapControllers();

app.Run();
