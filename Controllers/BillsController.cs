namespace ZDZCode_Api.Controllers
{
    public class BillsController
    {
        public void Build(WebApplication app)
        {
            app.MapGet("/", () => "Hello World!");
        }
    }
}
