using Novin.Foodland.Core.Enums;
using System.Text.Json.Serialization;

namespace Novin.FoodLand.API.Security.DTOs
{
    public class RegisterRequestDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Fullname { get; set; }
        public ApplicationUserType Type { get; set; }
        public string? Email { get; set; }
    }
}
