using CW10.Service;

namespace CW10.Model
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Username { get; set; }

        public string Password { get; set; }

        public User()
        {
        }

        public User(string username, string password)
        {
            Validation.ValidateNull(username, "Username is required.");
            Validation.ValidateNull(password, "Password is required.");

            Username = username.Trim();
            Password = password;
        }

        public bool validatePassword(string password)
        {
            return Password == password;
        }
    }
}