using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using System.Text.Json;

namespace Core.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        protected override string path { get; } = AppDomain.CurrentDomain.BaseDirectory + "users.txt";
        protected string NameFile = "users.txt";
        public User GetByName(string login)
        {
            var userList = GetAll(NameFile);
            for (int i = 0; i < userList.Count(); i++)
            {
                User usertest = userList.ElementAt(i);
                if (usertest.Name.Equals(login))
                {
                    return usertest;
                }
            }
            return null;
        }
        public bool Exist(string name)
        {
            foreach (var user in GetAll(NameFile))
            {
                if (user.Name.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }
        public User Create(User user)
        {
            List<User> userList = GetAll(NameFile).ToList();
            user.Id = GetNextId();
            userList.Add(user);
            UpdateFile(userList);
            return user;
        }
        public User Update(User user)
        {
            List<User> userList = GetAll(NameFile).ToList();
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
            List<User> userList = GetAll(NameFile).ToList();
            userList.RemoveAll(x => x.Id == idUser);
            UpdateFile(userList);
        }
        private int GetNextId()
        {
            var userList = GetAll(NameFile);
            int lastID = userList.LastOrDefault()?.Id ?? 0;
            return ++lastID;
        }
    }
}
