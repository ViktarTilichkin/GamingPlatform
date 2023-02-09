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
        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
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
                sr1.Close();
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
        public User GetOne(string login)
        {
            List<User> userList = GetAll();
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Name.Equals(login))
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
                if (userList[i].Name.Equals(newuser.Name))
                {
                    return null;
                }
            }
            userList.Add(newuser);
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            StreamWriter sw1 = new StreamWriter($"{path}users.txt");
            for (int i = 0; i < userList.Count; i++)
            {
                string json = JsonSerializer.Serialize<User>(userList[i], serializeoptions);
                sw1.WriteLine(json);
            }
            sw1.Close();
            return newuser;
        }
        public User Update(User user)
        {
            List<User> userList = GetAll();
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Name.Equals(user.Name))
                {
                    userList[i] = user;

                }
            }
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            StreamWriter sw1 = new StreamWriter($"{path}users.txt");
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i] != null)
                {
                    string json = JsonSerializer.Serialize<User>(userList[i], serializeoptions);
                    sw1.WriteLine(json);
                }
            }
            sw1.Close();
            return null;
        }
        public User Delete(User delUser)
        {
            List<User?> userList = GetAll();
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Name.Equals(delUser.Name))
                {
                    userList[i] = null;
                }
            }
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            StreamWriter sw1 = new StreamWriter($"{path}users.txt");
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i] != null)
                {
                    string json = JsonSerializer.Serialize<User>(userList[i], serializeoptions);
                    sw1.WriteLine(json);
                }
            }
            sw1.Close();
            return delUser;
        }
    }
}
