using Microsoft.AspNetCore.Mvc;
using ZDZCode_Api.Src.Application.Dtos;
using ZDZCode_Api.Src.Domain.Entities;
using ZDZCode_Api.Src.Domain.Repositories;

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
        public BillsPayload GetBills(int userID)
        {
            // GET BILLS BASED ON THE USER ID
            var bills = BillsRepository.GetAll(userID.ToString());

            var billsDto = bills.Select(bill => new BillsDto
            (
                bill.id,
                bill.name,
                bill.value,
                bill.date,
                bill.userID
            ));

            // Check if billsDto is empty
            if (!billsDto.Any())
            {
                return new BillsPayload
                (
                    [],
                    $"No bills found for the specified user ID: {userID}"
                );
            }

            return new BillsPayload
            (
                billsDto,
                "Bills retrieved successfully."
            );
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

        // DELETE ROUTE
        [HttpDelete("bills/delete/{id}")]
        async public Task<ActionResult> DeleteBill(Guid id)
        {
            _logger.LogInformation("{bill id:}", id);

            // PASS IT TO THE REPOSITORY
            var isCreated = await BillsRepository.Delete(id);

            // RETURN RESPONSE
            if (isCreated)
            {
                return Ok("Bill deleted");
            }
            else
            {
                return StatusCode(500, "Error while trying to delete the bill");
            }
        }

        // UPDATE ROUTE
        [HttpPut("bills/update/{id}")]
        async public Task<ActionResult> UpdateBill(Guid id, UpdateBillDto billUpdate)
        {
            // VALIDATE THE BODY AMD SERIALIZE IT
            ArgumentNullException.ThrowIfNull(billUpdate);

            // PASS IT TO THE REPOSITORY
            var updatedBill = await BillsRepository.Update(id, billUpdate);

            // RETURN RESPONSE
            if (updatedBill != null)
            {
                return Ok(updatedBill);
            }
            else
            {
                return StatusCode(500, "Error while trying to update the bill");
            }
        }
    }
}
