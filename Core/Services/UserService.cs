using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Services
{
    public class UserService
    {
        private readonly UserRepository _UserRepsitory = new UserRepository();
        public User? Login(string login, string password)
        {
            User? user = _UserRepsitory.GetByName(login);
            if (user != null && user.Password.Equals(password))
            {
                return user;
            }
            return null;
        }
        public User? Create(string name, string password)
        {
            try
            {
                if (!_UserRepsitory.Exist(name))
                {
                    User newUser = new User(name, password);
                    return _UserRepsitory.Create(newUser);

                }
                Console.WriteLine("Error");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public User? Update(User user, string password)
        {

            if (user == null) throw new ArgumentNullException(nameof(user));
            try
            {
                user.Password = password;
                return _UserRepsitory.Update(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public bool Delete(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            try
            {
                _UserRepsitory.Delete(user.Id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
//UserRepository data2 = new UserRepository();
//Console.WriteLine(data2.Login("admin", "1234"));
//Console.WriteLine("hello");
//User user = new User(2, "poluadmin", "1234");
//Console.WriteLine(data2.Create(user));
//User user1 = new User(3, "poluadmin2", "1234");
//Console.WriteLine(data2.Create(user1));
//User user2 = new User(4, "poluadmin3", "1234");
//Console.WriteLine(data2.Create(user2));
//Console.WriteLine("wrongcreate");
//User user4 = new User(5, "poluadmin3", "1234");
//Console.WriteLine(data2.Create(user4));
//List<User> test = data2.GetAll();
//foreach (var item in test)
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine("login");
//Console.WriteLine(data2.Login("poluadmin2", "1234"));
//Console.WriteLine("login");
//Console.WriteLine(data2.Login("www2", "1234"));
//Console.WriteLine("delete");
//Console.WriteLine(data2.Delete(user2));
//Console.WriteLine("delete end");
//test = data2.GetAll();
//foreach (var item in test)
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine("update");
//user2 = new User(11, "poluadmin", "1321545215");
//Console.WriteLine(data2.Update(user2));
//test = data2.GetAll();
//foreach (var item in test)
//{
//    Console.WriteLine(item);
//}