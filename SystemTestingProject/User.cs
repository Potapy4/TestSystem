using System;
using System.Collections.Generic;

namespace SystemTestingProject
{
    public class User
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public virtual List<ResultExam> Result { get; set; }
    }

}
