namespace HMS_API.Models.Dto
{
    public class SignUpDTO
    {
        public string? firstName { get; set; }
        public string? MiddleName { get; set; }
        public string? lastName { get; set; }
        public string? gender { get; set; }
        public DateTime dob { get; set; }
        public int age { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public int zip { get; set; }
        public string? country { get; set; }
        public string? referredBy { get; set; }

    }
}
