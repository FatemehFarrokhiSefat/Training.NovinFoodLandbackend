namespace Novin.FoodLand.API.Security.DTOs
{
    public class LoginResultsDTo
    {
        public string Message { get; set; }
        public bool IsOk { get; set; }
        public string Token { get; set; }
        public string Type { get; set; }
    }
}
