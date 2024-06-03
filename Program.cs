using Microsoft.EntityFrameworkCore;
using ZDZCode_Api.Src.Application.Controllers;
using ZDZCode_Api.Src.Infrastructure.Factory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbAdapter>(opt => opt.UseInMemoryDatabase("BillsManagment"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

// INICIALIZE THE APPLICATION CONTROLLERS
ControllersFactory controllersFactory = new ();

// INICIALIZE THE API ROUTES
Routes routes = new(app, controllersFactory.BillsController);

app.Run();
