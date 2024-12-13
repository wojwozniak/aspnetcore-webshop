namespace WebApi.Models
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string? Message { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
