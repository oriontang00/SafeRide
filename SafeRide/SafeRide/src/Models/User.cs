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
        public string FirstName { get { return firstName; } set { this.firstName = value; } }
        public string LastName { get { return lastName; } set { this.lastName = value; } }
        public string UserName { get { return userName; } set { this.userName = value; } }
        public string Password { get { return password; } set { this.password = value; } }
        public string UserId { get { return userId; } set { this.userId = value; } }
        public string PhoneNum { get { return phoneNum; } set { this.phoneNum = value; } }

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
