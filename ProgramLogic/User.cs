using System;

namespace ProgramLogic
{
    public class User
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthday { get; private set; }
        private bool isAdmin;

        public User(string Firstname, string Lastname, string Username, string Password, string Email, DateTime Birthday, bool isAdmin)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.Birthday = Birthday;
            this.isAdmin = isAdmin;
        }
    }
}
