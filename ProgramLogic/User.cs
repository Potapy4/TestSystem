using System;

namespace ProgramLogic
{
    public class User
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Username { get; private set; }
        public DateTime Date { get; private set; }
        public string City { get; private set; }
        public string Sex { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthday { get; private set; }
        private bool isAdmin;

<<<<<<< HEAD
        public User(string Firstname, string Lastname, string Username, string Password, string Email, DateTime Birthday, bool isAdmin)
=======
        public User(string Firstname, string Lastname, string Username, DateTime Date, string City, string Sex, string Email, string PhoneNumber, string Password, bool isAdmin=false)
>>>>>>> refs/heads/Roman
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Username = Username;
            this.Date = Date;
            this.Password = Password;
<<<<<<< HEAD
            this.Email = Email;
            this.Birthday = Birthday;
=======
            this.City = City;
            this.Sex = Sex;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
>>>>>>> refs/heads/Roman
            this.isAdmin = isAdmin;
        }
    }
}
