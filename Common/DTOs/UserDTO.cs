namespace Common.DTOs
{
    public class UserDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Info { get; set; }
    }
}
