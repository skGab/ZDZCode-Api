using System.Text.Json;
using ZDZCode_Api.Src.Application.Controllers;

namespace ZDZCode_Api.Src.Infrastructure.Factory
{
    public class Routes
    {
        public Routes(WebApplication app, BillsController billsController)
        {
            app.MapGet("/", () => "ZDZCode Bills Management API!");

            // GET BILLS
            app.MapGet("/bills/{userID}", billsController.GetBills);
        }
    }
}
