using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ZDZCode_Api.Src.Application.Dtos;
using ZDZCode_Api.Src.Domain.Entities;
using ZDZCode_Api.Src.Domain.Repositories;

namespace ZDZCode_Api.Src.Application.Controllers
{
    [ApiController]
    [FormatFilter]
    [Route("/")]
    public class UserController(IUserRepository userRepository, ILogger<UserController> logger) : ControllerBase
    {
        private readonly IUserRepository UserRepository = userRepository;
        private readonly ILogger<UserController> _logger = logger;

        // AUTHENTICATE USER
        [HttpPost("user/auth")]
        public ActionResult AuthenticateUser(FormPayloadDto formPayload)
        {
            // VALIDATE THE BODY AMD SERIALIZE IT
            ArgumentNullException.ThrowIfNull(formPayload);

            // PASS IT TO THE REPOSITORY
            Task<bool> authentication = UserRepository.AuthenticateUser(formPayload.email);

            // RETURN RESPONSE
            if (authentication.Result)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        // AUTHENTICATE USER
        [HttpPost("user/create")]
        public ActionResult CreateUser(UserEntity userEntity)
        {
            // VALIDATE THE BODY AMD SERIALIZE IT
            ArgumentNullException.ThrowIfNull(userEntity);

            // PASS IT TO THE REPOSITORY
            Task<bool> isCreated = UserRepository.Create(userEntity);

            // RETURN RESPONSE
            if (isCreated.Result)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(500,false);
            }
        }
    }
}
