using ZDZCode_Api.Src.Application.Controllers;
using ZDZCode_Api.Src.Infrastructure.Database;

namespace ZDZCode_Api.Src.Infrastructure.Factory
{
    public class ControllersFactory
    {
        public BillsController BillsController { get; private set; }

        private readonly BillsRepository BillsRepository;

        public ControllersFactory()
        {
            BillsRepository = new();

            BillsController = new(BillsRepository);
        }
    }
}
