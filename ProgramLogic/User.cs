namespace ProgramLogic
{
    public class User
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Username { get; private set; }
        public string City { get; private set; }
        public string Sex { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        private bool isAdmin;

        public User(string Firstname, string Lastname, string Username, string City, string Sex, string Email, string PhoneNumber, string Password, bool isAdmin=false)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Username = Username;
            this.Password = Password;
            this.City = City;
            this.Sex = Sex;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.isAdmin = isAdmin;
        }
    }
}
