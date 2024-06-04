using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZDZCode_Api.Src.Application.Controllers;
using ZDZCode_Api.Src.Domain.Entities;
using ZDZCode_Api.Src.Domain.Repositories;

namespace ZDZCode_Api.Src.Infrastructure.Database
{
    public class BillsRepository(ILogger<BillsController> logger, DbAdapter dbAdapter) : IBillsRepository
    {
        private readonly DbAdapter _dbAdapter = dbAdapter;
        private readonly ILogger<BillsController> _logger = logger;

        // GET ALL BILLS
        BillsEntity[] IBillsRepository.GetAll(string usedID)
        {
            return [.. _dbAdapter.Bills.Where(b => b.userID == usedID)];
        }

        // CREATE BILL
        // NEED DATA VALIDATION
        async Task<bool> IBillsRepository.Create(BillsEntity data)
        {
            _dbAdapter.Add(data);

            var task = await _dbAdapter.SaveChangesAsync();

            if (task == 0) { return false; };

            _logger.LogInformation("ID do usuario: {UserId}", data.userID);

            return true;
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
