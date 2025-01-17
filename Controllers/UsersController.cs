using HMS_API.Models.APIResponses;
using HMS_API.Models.Dto;
using HMS_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HMS_API.Controllers
{
    [Route("api/UsersAuth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private APIResponse _response;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] SignUpRequestDto model)
        {
            var user = await _userRepository.SignUp(model);
            if (user.firstName == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
