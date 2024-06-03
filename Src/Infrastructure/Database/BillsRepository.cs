using Microsoft.Extensions.Logging;
using ZDZCode_Api.Src.Application.Controllers;
using ZDZCode_Api.Src.Domain.Entities;
using ZDZCode_Api.Src.Domain.Repositories;

namespace ZDZCode_Api.Src.Infrastructure.Database
{
    public class BillsRepository(ILogger<BillsController> logger, DbAdapter dbAdapter) : IBillsRepository
    {
        // LOGGER
        private readonly DbAdapter _dbAdapter = dbAdapter;
        private readonly ILogger<BillsController> _logger = logger;

        // GET ALL BILLS
        BillsEntity[] IBillsRepository.GetAll(string usedID)
        {
            string log = $"{"userID: "}{usedID}";

            _logger.LogWarning(message: log);

            BillsEntity cemig = new ("123213", "Cemig", "1500", new DateTime());
            BillsEntity copasa = new ("1251243213", "Copasa", "2000", new DateTime());

            BillsEntity[] bills = [cemig, copasa];

            return bills;
        }

        // CREATE BILL
        void IBillsRepository.Create(BillsEntity data)
        {
            throw new NotImplementedException();
        }

        // DELETE BILL
        void IBillsRepository.Delete(string id)
        {
            throw new NotImplementedException();
        }

        // UPDATE BILL
        BillsEntity IBillsRepository.Update(string id)
        {
            throw new NotImplementedException();
        }
    }
}
