using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services;
using Core.Models;

namespace Core.Controller
{
    public class PlatformController
    {
        private UserService servicUser = new UserService();
        public (bool, User?) Login()
        {
            return (true, null);
        }
        public (bool, User?) Create()
        {
            Console.WriteLine("Hello! Hello! Do you want to create a user? Y/N");
            string? menu = Console.ReadLine();
            if (!string.IsNullOrEmpty(menu) && menu.ToUpper().Equals("Y"))
            {
                Console.WriteLine("Great!");
                Console.Write("Enter Name: ");
                string? name = Console.ReadLine();
                Console.Write("Enter Password: ");
                string? password = Console.ReadLine();
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
                {
                    int id = 10;
                    User? userID = servicUser.Create(id, name, password);
                    if (userID != null)
                    {
                        Console.WriteLine("Succes");
                        return (true, userID);
                    }
                }
            }
            return (false, null);
        }
        public (bool, User?) Update(User? user)
        {
            if (user == null)
            {
                return (false, null);
            }
            Console.WriteLine("Hello! Hello! Do you want to edit your account? Y/N");
            string? menu = Console.ReadLine();
            if (!string.IsNullOrEmpty(menu) && menu.ToUpper().Equals("Y"))
            {
                Console.WriteLine("Great!");
                Console.Write("Enter new Password: ");
                string? password = Console.ReadLine();
                if (!string.IsNullOrEmpty(password))
                {
                    int id = 10;

                    User? idUser = servicUser.Update(user.Id, user.Name, password);
                    if (idUser != null)
                    {
                        Console.WriteLine("Succes");
                        return (true, idUser);
                    }
                }
            }
            return (true, null);
        }
        public (bool, User?) Delete(User? user)
        {
            if (user == null)
            {
                return (false, null);
            }
            Console.WriteLine("Hello!  Do you want to delete your account? Y/N");
            string? menu = Console.ReadLine();
            if (menu.ToUpper().Equals("Y"))
            {
                Console.WriteLine("Great!");
                int id = 10;
                User? idUser = servicUser.Delete(user.Id, user.Name, user.Password);
                if (idUser != null)
                {
                    Console.WriteLine("Succes");
                    return (false, null);
                }
            }
            return (false, null);
        }

    }
}

