namespace ProgramLogic
{
    public class User
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        private bool isAdmin;

        public User(string Firstname, string Lastname, string Username, string Password, bool isAdmin)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Username = Username;
            this.Password = Password;
            this.isAdmin = isAdmin;
        }
    }
}
