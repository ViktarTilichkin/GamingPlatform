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
            Console.WriteLine("Great!");
            Console.WriteLine("Enter your username and password");
            Console.Write("Enter Name: ");
            string? name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string? password = Console.ReadLine();
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
            {
                User? userID = servicUser.Login(name, password);
                if (userID != null)
                {
                    Console.WriteLine("Succes");
                    return (true, userID);
                }
            }
            return (false, null);

        }
        public (bool, User?) Create()
        {
            Console.WriteLine("Great!");
            Console.WriteLine("Enter the Name (minimum 3 characters) and enter the password (minimum 4 characters)");
            Console.Write("Enter Name: ");
            string? name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string? password = Console.ReadLine();
            if (name.Length >= 3 && password.Length >= 4)
            {
                User? userID = servicUser.Create(name, password);
                if (userID != null)
                {
                    Console.WriteLine("Succes");
                    Thread.Sleep(3000);
                    return (true, userID);
                }
            }
            Console.WriteLine("Oooopp! Something went wrong!");
            Thread.Sleep(3000);
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
                Console.Write("Enter Name: ");
                string? name = Console.ReadLine();
                Console.Write("Enter Password: ");
                string? password = Console.ReadLine();
                if (name.Length >= 3 && password.Length >= 4)
                {
                    User cloneUser = user.Clone() as User;
                    cloneUser = servicUser.Update(cloneUser, name, password);
                    if (cloneUser != null)
                    {
                        Console.WriteLine("Succes");
                        Thread.Sleep(3000);
                        return (true, cloneUser);
                    }
                }
            }
            Console.WriteLine("Oooopp! Something went wrong!");
            Thread.Sleep(4000);
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
                if (servicUser.Delete(user))
                {
                    Console.WriteLine("Succes");
                    Thread.Sleep(4000);
                    return (false, null);
                }
            }
            Console.WriteLine("Oooopp! Something went wrong!");
            Thread.Sleep(4000);
            return (false, null);
        }
    }
}

