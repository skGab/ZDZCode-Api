using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ZDZCode_Api.Src.Application.Dtos;
using ZDZCode_Api.Src.Domain.Entities;
using ZDZCode_Api.Src.Domain.Repositories;
using static ZDZCode_Api.Src.Application.Controllers.BillsController;

namespace ZDZCode_Api.Src.Application.Controllers
{
    [ApiController]
    [FormatFilter]
    [Route("/")]
    public class BillsController(IBillsRepository billsRepository, ILogger<BillsController> logger) : ControllerBase
    {
        private readonly IBillsRepository BillsRepository = billsRepository;
        private readonly ILogger<BillsController> _logger = logger;

        // MAIN ROUTE
        [HttpGet]
        public string MainRoute() => "ZDZCode Bills Management API!";

        // GETT BILLS
        [HttpGet("bills/{userID}")]
        public IEnumerable<BillsDto> GetBills(int userID)
        {
            // VALIDATE USER ID AND PASS TO STRING

            // GET BILLS BASED ON THE USE ID
            var bills = BillsRepository.GetAll(userID.ToString());

            return bills.Select(bill => new BillsDto
            (
                bill.id,
                bill.name,
                bill.value,
                bill.date,
                bill.userID
            ));
        }

        // CREATE BILLS
        [HttpPost("bills/create")]
        public ActionResult CreateBill(BillsEntity billsEntity)
        {
            // VALIDATE THE BODY AMD SERIALIZE IT
            ArgumentNullException.ThrowIfNull(billsEntity);

            // PASS IT TO THE REPOSITORY
            Task<bool> isCreated = BillsRepository.Create(billsEntity);

            // RETURN RESPONSE
            if (isCreated.Result)
            {
                return Ok("Bill Successfully stored");
            }
            else
            {
                return StatusCode(500, "Error while storing the bill");
            }
        }

    }
}
