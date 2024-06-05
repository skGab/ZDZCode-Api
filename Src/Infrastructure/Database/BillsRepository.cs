using ZDZCode_Api.Src.Application.Controllers;
using ZDZCode_Api.Src.Application.Dtos;
using ZDZCode_Api.Src.Domain.Entities;
using ZDZCode_Api.Src.Domain.Repositories;

namespace ZDZCode_Api.Src.Infrastructure.Database
{
    public class BillsRepository(ILogger<BillsController> logger, DbAdapter dbAdapter) : IBillsRepository
    {
        private readonly DbAdapter _dbAdapter = dbAdapter;
        private readonly ILogger<BillsController> _logger = logger;

        // GET ALL BILLS
        BillsEntity[] IBillsRepository.GetAll(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                _logger.LogError("User ID is null or empty");
                return [];
            }

            return [.. _dbAdapter.Bills.Where(b => b.userID == userID)];
        }

        // CREATE BILL
        async Task<bool> IBillsRepository.Create(BillsEntity data)
        {
            if (data == null)
            {
                _logger.LogError("BillsEntity data is null.");
                return false;
            }

            try
            {
                _dbAdapter.Add(data);

                var task = await _dbAdapter.SaveChangesAsync();

                if (task == 0)
                {
                    _logger.LogWarning("Failed to save changes to the database for user ID: {UserId}", data.userID);
                    return false;
                };

                _logger.LogInformation("ID do usuario: {UserId}", data.userID);

                return true;

            }
            catch (Exception error)
            {
                _logger.LogError(error, "An error occurred while creating the bill for user ID: {UserId}", data.userID);
                return false;
            }
        }

        // DELETE BILL
        async Task<bool> IBillsRepository.Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Bill ID is null or empty.");
                return false;
            }

            try
            {
                var bill = await _dbAdapter.FindAsync<BillsEntity>(id);

                if (bill == null)
                {
                    _logger.LogWarning("Bill with ID: {BillId} not found.", id);
                    return false;
                }

                _dbAdapter.Remove(bill);
                var result = await _dbAdapter.SaveChangesAsync();

                if (result == 0)
                {
                    _logger.LogWarning("Failed to save changes to the database for bill ID: {BillId}", id);
                    return false;
                }

                return true;
            }
            catch (Exception error)
            {
                _logger.LogError(error, "An error occurred while deleting the bill, ID: {bill ID}", id);
                return false;
            }
        }

        // UPDATE BILL
       async Task<BillsEntity?> IBillsRepository.Update(Guid id, UpdateBillDto billUpdate)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Bill ID is null or empty.");
                return null;
            }

            try
            {
                var bill = await _dbAdapter.Bills.FindAsync(id);

                if (bill is null)
                {
                    _logger.LogError("{Bill was not found for update with id: }",id);

                    return null;
                }

                bill.name = billUpdate.name;
                bill.value = billUpdate.value;

                await _dbAdapter.SaveChangesAsync();

                return bill;

            }
            catch (Exception error)
            {
                _logger.LogError("{Error while trying to update the bill}", error);
                return null;
            }

        }
    }
}
