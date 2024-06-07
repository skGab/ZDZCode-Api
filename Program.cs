using Microsoft.EntityFrameworkCore;
using ZDZCode_Api.Src.Domain.Repositories;
using ZDZCode_Api.Src.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddDbContext<DbAdapter>(opt => opt.UseInMemoryDatabase("BillsManagment"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Logging.AddConsole();

// ADD SERVICES TO THE CONTAINER
builder.Services.AddControllers();
builder.Services.AddScoped<DbAdapter>();
builder.Services.AddScoped<IBillsRepository, BillsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
