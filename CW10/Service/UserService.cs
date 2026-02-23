using CW10.Model;
using CW10.Repository.Interfaces;
using CW10.Service.interfaces;

namespace CW10.Service
{
    internal class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordPolicy _passwordPolicy;

        public UserService(IUserRepository userRepository, IPasswordPolicy passwordPolicy)
        {
            _userRepository = userRepository;
            _passwordPolicy = passwordPolicy;
        }

        public User Register(string username, string password)
        {
            Validation.ValidateNull(username, "Username is required.");
            Validation.ValidateNull(password, "Password is required.");

            if (_userRepository.GetByUsername(username) != null)
                throw new InvalidOperationException("this username is already exist");
            _passwordPolicy.Validate(username, password);

            var user = new User(username.Trim(), password.Trim());
            _userRepository.Add(user);
            return user;
        }

        public User Login(string username, string password)
        {
            Validation.ValidateNull(username, "Username is required.");
            Validation.ValidateNull(password, "Password is required.");

            var user = _userRepository.GetByUsername(username.Trim());
            if (user == null || !user.validatePassword(password))
                throw new UnauthorizedAccessException("invalid username or password");

            return user;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public bool Delete(Guid id)
        {
            return _userRepository.Delete(id);
        }

        /*public void UpdatePassword(Guid id, string newPassword)
        {
            var user = FindUserByID(id);
            if (user.Password == newPassword) throw new Exception("password is the same with old pass");
            _passwordPolicy.Validate(user.Username, newPassword);
            user.Password = newPassword;
            _userRepository.Update(user);
        }*/

        private User FindUserByID(Guid id)
        {
            var foundUser = _userRepository.GetById(id);
            if (foundUser == null) throw new KeyNotFoundException($"user with id {id.ToString()} not found");
            return foundUser;
        }
    }
}