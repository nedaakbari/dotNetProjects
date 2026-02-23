using System.Text.Json;
using CW10.Model;
using CW10.Repository.Interfaces;

namespace CW10.Repository
{
    public class JsonUserRepository : IUserRepository
    {
        private readonly string _path = "Data/users.json";
        private List<User> userList;

        public JsonUserRepository()
        {
            userList = FileExist();
        }

        private List<User> FileExist()
        {
            try
            {
                var directory = Path.GetDirectoryName(_path);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                if (!File.Exists(_path))
                {
                    File.WriteAllText(_path, "[]");
                    return new List<User>();
                }
                else
                {
                    var json = File.ReadAllText(_path);
                    if (string.IsNullOrWhiteSpace(json))
                        return new List<User>();

                    var data = JsonSerializer.Deserialize<List<User>>(json);
                    return data ?? new List<User>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void WriteAll(List<User> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_path, json);
            //            File.WriteAllText(_path, JsonSerializer.Serialize(users));
        }

        public void Add(User user)
        {
            userList.Add(user);
            WriteAll(userList);
        }

        public bool Delete(Guid id)
        {
            foreach (var user in userList)
            {
                if (user.Id == id)
                {
                    userList.Remove(user);
                    WriteAll(userList);
                    return true;
                }
            }

            return false;
        }

        public List<User> GetAll()
        {
            // return JsonSerializer.Deserialize<List<User>>(File.ReadAllText(_path));
            return userList;
        }

        public User? GetById(Guid id)
        {
            foreach (var user in userList)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }

        public User? GetByUsername(string username)
        {
            foreach (var item in userList)
            {
                if (item.Username == username)
                {
                    return item;
                }
            }

            return null;
        }

        public void Update(User user)
        {
            foreach (var item in userList)
            {
                if (item.Id == user.Id)
                {
                    item.Password = user.Password;
                    WriteAll(userList);
                }
            }
        }

        /*public void Update(Guid id, string password)
        {
            var userList = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(_path));
            foreach (var item in userList)
            {
                if (item.Id == id)
                {
                    item.Password = password;
                    WriteAll(userList);
                }
            }
        }*/
    }
}