namespace SafeRide.src.Models
{
    public class UserSecurityModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Passphrase { get; set; }
        public string Role { get; set; }
        public bool Valid { get; set; }
    }
}
