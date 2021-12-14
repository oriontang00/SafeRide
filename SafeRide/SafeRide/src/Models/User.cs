namespace SafeRide.src.Models
{
    public class User
    {
        private string firstName;
        private string lastName;
        private string userName;
        private string password;
        private string userId;
        private string phoneNum;
        public string FirstName { get { return firstName; } set { this.firstName=value; } }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public string PhoneNum { get; set; }

        public User()
        {
            FirstName = "";
            LastName = "";
            UserName = "";
            Password = "";
            UserId = "";
            PhoneNum = "";
        }
        public User(string firstName, string lastName, string userName, string password, string userId, string phoneNum)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            UserId = userId;
            PhoneNum = phoneNum;
        }
        public override string ToString()
        {
            return $"User : \n" +
                $"FirstName : {FirstName}\n" +
                $"LastName : {LastName}\n" +
                $"UserName : {UserName}\n" +
                $"UserId : {UserId}\n" +
                $"PhoneNum : {PhoneNum}";
        }

        public override int GetHashCode()
        {
            return this.UserId.GetHashCode();
        }
    }
}
