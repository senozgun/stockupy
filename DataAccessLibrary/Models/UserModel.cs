using System;

namespace DataAccessLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
