using Microsoft.AspNetCore.Mvc;
using ZDZCode_Api.Src.Domain.Entities;
using ZDZCode_Api.Src.Domain.Repositories;

namespace ZDZCode_Api.Src.Application.Controllers
{
    [ApiController]
    [FormatFilter]
    public class BillsController(IBillsRepository billsRepository) : ControllerBase
    {
        private readonly IBillsRepository BillsRepository = billsRepository;

        [HttpGet]
        public BillsEntity[] GetBills(string userID)
        {
            // GET USER ID AND VALIDATE IT 
            if (string.IsNullOrEmpty(userID))
            {
                throw new ArgumentException($"'{nameof(userID)}' não pode ser nulo nem vazio.", nameof(userID));
            }

            // GET BILLS BASED ON THE USE ID
            var bills = BillsRepository.GetAll(userID);

            // RETURN TO THE FRONT-END 
            return bills;
        }

    }
}
