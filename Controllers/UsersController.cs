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
            _response = new();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] SignUpRequestDto model)
        {
            bool ifMobileNumberUnique = _userRepository.IsUniqueUser(model.mobile);
            if (!ifMobileNumberUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Mobile number is already registered.");
                return BadRequest(_response);
            }
            var user = await _userRepository.SignUp(model);
            if (user == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error occured while signup.");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            //_response.Result = user;
            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] SignInRequestDto model)
        {
            bool ifMobileNumberUnique = _userRepository.IsUniqueUser(model.MobileNumber);
            if (ifMobileNumberUnique)
            {
                //Generate Otp logic here
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Mobile number is already registered.");
                return BadRequest(_response);
            }

            var loginResponse = await _userRepository.SignIn(model);
            if (string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }
    }
}
