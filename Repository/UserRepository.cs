using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using HMS_API.Data;
using HMS_API.Models;
using HMS_API.Models.Dto;
using HMS_API.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using static System.Net.WebRequestMethods;

namespace HMS_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private string secretKey;
        public UserRepository(ApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            secretKey = configuration.GetValue<string>("ApiSetting:Secret");
        }

        public bool IsUniqueUser(string mobilenumber)
        {
            var userMobileno = _dbContext.Users.FirstOrDefault(m => m.mobile == mobilenumber);
            if (userMobileno == null)
            {
                return true;
            }
            else
            {
                return false;
            }        
        }

        public async Task<SignInResponseDto> SignIn(SignInRequestDto signInRequestDto)
        {
            var user = _dbContext.Users.FirstOrDefault(m=>m.mobile == signInRequestDto.MobileNumber);
            if (user == null)
            {
                return new SignInResponseDto()
                {
                    Token = "",
                    User = null
                    
                };
            }
            //if User was found generate JWT Token

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.MobilePhone, user.mobile.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            SignInResponseDto loginresponse = new SignInResponseDto()
            {
                Token = tokenHandler.WriteToken(token),
                User = _mapper.Map<UserDTO>(user),               
            };

            return loginresponse;
        }
            
        public async Task<UserDTO> SignUp(SignUpRequestDto signUpRequestDto)
        {
            try
            {
                User user = _mapper.Map<User>(signUpRequestDto);
                await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
            }
            return new UserDTO();
        }
    }
}
