using Microsoft.EntityFrameworkCore;
using ZDZCode_Api.Src.Application.Controllers;
using ZDZCode_Api.Src.Domain.Repositories;
using ZDZCode_Api.Src.Infrastructure.Database;
using ZDZCode_Api.Src.Infrastructure.Factory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbAdapter>(opt => opt.UseInMemoryDatabase("BillsManagment"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Logging.AddConsole();

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddSingleton<IBillsRepository, BillsRepository>();
builder.Services.AddTransient<BillsController>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// INICIALIZE THE APPLICATION CONTROLLERS
// ControllersFactory controllersFactory = new ();
var billsController = app.Services.GetRequiredService<BillsController>();

// INICIALIZE THE API ROUTES
Routes routes = new(app, billsController);

app.UseHttpsRedirection();

app.Run();
