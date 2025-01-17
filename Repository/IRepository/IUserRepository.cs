using HMS_API.Models;
using HMS_API.Models.Dto;

namespace HMS_API.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string mobilenumber);

        Task<SignInResponseDto> SignIn(SignInRequestDto signInRequestDto);

        Task<UserDTO> SignUp(SignUpRequestDto signUpRequestDto);

    }
}
