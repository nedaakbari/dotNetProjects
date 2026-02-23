using CW10.Model;

namespace CW10.Repository.Interfaces
{
    internal interface IUserRepository
    {
        public void Add(User user);
        public bool Delete(Guid id);
        public User? GetById(Guid id);
        public List<User> GetAll();
        public User? GetByUsername(string username);
        public void Update(User user);
    }
}