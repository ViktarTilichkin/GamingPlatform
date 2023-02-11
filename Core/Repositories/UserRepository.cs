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
        public UserRepository()
        {
            //StreamWriter sw1 = new StreamWriter($"{path}users.txt", true);
            //sw1.Close();
        }
        public User GetByName(string login)
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
        public bool Exist(string name)
        {
            List<User> userList = GetAll();
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Name.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }
        public User Create(User user)
        {
            List<User> userList = GetAll();
            user.Id = GetNextId();
            userList.Add(user);
            UpdateFile(userList);
            return  user;
        }
        public User Update(User user)
        {
            List<User> userList = GetAll();
            int index = userList.FindIndex(x => x.Id == user.Id);
            if (index < 0)
            {
                return null;
            }
            userList[index] = user;
            UpdateFile(userList);
            return user;
        }
        public void Delete(int idUser)
        {
            List<User?> userList = GetAll();
            userList.RemoveAll(x => x.Id == idUser);
            UpdateFile(userList);
        }
        private int GetNextId()
        {
            List<User?> userList = GetAll();
            int lastID = userList.LastOrDefault()?.Id ?? 0;
            return ++lastID;
        }
        private List<User> GetAll()
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
            catch (FileNotFoundException)
            {
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UpdateFile(List<User?> userList)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }

    }
}
