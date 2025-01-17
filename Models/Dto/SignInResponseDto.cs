namespace HMS_API.Models.Dto
{
    public class SignInResponseDto
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
        public int Otp { get; set; }
    }
}
