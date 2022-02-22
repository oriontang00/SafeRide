using System.ComponentModel.DataAnnotations;

namespace SafeRide.src.Models
{
    public class UserSecurityModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
