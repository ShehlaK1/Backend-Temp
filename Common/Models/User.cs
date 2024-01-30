using Common.Models;

namespace Common.Model
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Info { get; set; }

    }
}
