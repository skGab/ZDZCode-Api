using Microsoft.EntityFrameworkCore;
using ZDZCode_Api.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BillsDb>(opt => opt.UseInMemoryDatabase("BillsManagment"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

// CREATE THE BILLS CONTROLLER INSTANCE
var billsController = new BillsController();
billsController.Build(app);

app.Run();
