using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services;

namespace Core.Controller
{
    public class PlatformController
    {
        private UserService servicUser = new UserService();
        public (bool, int) Login()
        {
            return (true, 0);
        }
        public (bool, int) Create()
        {
            Console.WriteLine("Hello! Hello! Do you want to create a user? Y/N");
            string? menu = Console.ReadLine();
            if (!string.IsNullOrEmpty(menu) && menu.Equals("Y"))
            {
                Console.WriteLine("Great!");
                Console.Write("Enter Name: ");
                string? name = Console.ReadLine();
                Console.Write("Enter Password: ");
                string? password = Console.ReadLine();
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
                {
                    int id = 10;
                    servicUser.Create(id, name, password);
                    Console.WriteLine("Succes");
                    return (true, id);
                }
            }
            return (false, 0);
        }
        public (bool, int) Update()
        {
            return (true, 0);
        }
        public (bool, int) Delete()
        {
            return (true, 0);
        }
    }
}
