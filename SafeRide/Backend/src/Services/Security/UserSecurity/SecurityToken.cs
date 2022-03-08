using System.ComponentModel.DataAnnotations;

namespace SafeRide.src.Security.UserSecurity
{
    public class SecurityToken
    {
        [Required]
        public string Token { get; set; }
    }
}
