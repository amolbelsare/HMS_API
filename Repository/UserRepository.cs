using AutoMapper;
using HMS_API.Data;
using HMS_API.Models;
using HMS_API.Models.Dto;
using HMS_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HMS_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsUniqueUser(string mobilenumber)
        {
            throw new NotImplementedException();
        }

        public Task<SignInResponseDto> SignIn(SignInRequestDto signInRequestDto)
        {
            throw new NotImplementedException();
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
