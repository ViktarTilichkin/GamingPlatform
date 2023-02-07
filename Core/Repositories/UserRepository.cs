using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using System.Text.Json;

namespace Core.Repositories
{
    public class UserRepository
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory;
        private List<User> GetAll()
        {
            List<User> users = new List<User>();
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            }
            try
            {
                using StreamReader sr1 = new StreamReader($"{path}users.txt");
                string line = sr1.ReadLine();
                while (line != null)
                {
                    User user = JsonSerializer.Deserialize<User>(line, serializeoptions);
                    users.Add(user);
                    line = sr1.ReadLine();
                }
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
        public User Login(string login, string password)
        {
            List<User> userList = GetAll();
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Name.Equals(login) && userList[i].Password.Equals(password)
                {
                    return userList[i];
                }
            }
            return null;
        }
        public User Create(User newuser)
        {
            List<User> userList = GetAll();
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Name.Equals(login))
                {
                    return null;
                }
            }
            userList.Add(newuser);
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }
            StreamWriter sw1 = new StreamWriter($"{path}users.txt");
            sw1 = JsonSerializer.Serialize<User>(List<User>, serializeoptions);
            return newuser;
        }
        public user Update()
        {
            List<User> userList = GetAll();
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Name.Equals(login))
                {
                    return null;
                }
            }
            userList.Add(newuser);
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }
            StreamWriter sw1 = new StreamWriter($"{path}users.txt");
            sw1 = JsonSerializer.Serialize<User>(List<User>, serializeoptions);
            return newuser;
        }
        public bool Delete(User delUser)
        {
            List<User> userList = GetAll();
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Name.Equals(delUser.Name))
                {
                    userList.Remove(delUser)
                }
            }
            userList.Add(newuser);
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }
            StreamWriter sw1 = new StreamWriter($"{path}users.txt");
            sw1 = JsonSerializer.Serialize<User>(List<User>, serializeoptions);
            return newuser;
        }
    }
}
