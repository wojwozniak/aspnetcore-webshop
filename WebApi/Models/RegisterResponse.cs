namespace WebApi.Models
{
    public class RegisterResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
