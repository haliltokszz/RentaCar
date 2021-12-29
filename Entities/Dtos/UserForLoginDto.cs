using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}