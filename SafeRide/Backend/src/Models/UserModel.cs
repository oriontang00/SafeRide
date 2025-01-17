﻿namespace SafeRide.src.Models
{
    public class UserModel
    {
        private string firstName;
        private string lastName;
        private string userName;
        private string password;
        private string userId;
        private string phoneNum;
        private string isAdmin;
        private string enabled;
        private DateTime _lastLogin;
        private DateTime _dateRegistered;

        public string FirstName { get { return firstName; } set { this.firstName = value; } }
        public string LastName { get { return lastName; } set { this.lastName = value; } }
        public string UserName { get { return userName; } set { this.userName = value; } }
        public string Password { get { return password; } set { this.password = value; } }
        public string UserId { get { return userId; } set { this.userId = value; } }
        public string PhoneNum { get { return phoneNum; } set { this.phoneNum = value; } }
        public string IsAdmin { get { return isAdmin; } set { isAdmin = value; } }
        public string Enabled { get { return enabled; } set { enabled = value; } }
        public DateTime LastLogin{ get { return _lastLogin; } set { _lastLogin = value; } }
        public DateTime DateRegistered { get { return _dateRegistered; } set { _dateRegistered = value; } }

        public UserModel()
        {
            FirstName = "";
            LastName = "";
            UserName = "";
            Password = "";
            UserId = "";
            PhoneNum = "";
            isAdmin = "";
            enabled = "";
            LastLogin = default(DateTime);
            DateRegistered = default(DateTime);

        }
        public UserModel(string firstName, string lastName, string userName, string password, string userId, string phoneNum, string isAdmin, string enabled, DateTime lastLogin, DateTime dateRegistered)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            UserId = userId;
            PhoneNum = phoneNum;
            IsAdmin = isAdmin;
            Enabled = enabled;
            LastLogin = lastLogin;
            DateRegistered = dateRegistered;
        }
        public override string ToString()
        {
            return $"User : \n" +
                $"FirstName : {FirstName}\n" +
                $"LastName : {LastName}\n" +
                $"UserName : {UserName}\n" +
                $"UserId : {UserId}\n" +
                $"PhoneNum : {PhoneNum}\n" +
                $"IsAdmin : {IsAdmin}\n" +
                $"Enabled : {Enabled}\n" +
                $"LastLogin : {LastLogin}\n" +
                $"DateRegistered : {DateRegistered}";
        }
        public override int GetHashCode()
        {
            return this.UserId.GetHashCode();
        }
    }
}
