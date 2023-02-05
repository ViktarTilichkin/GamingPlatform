using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Core
{
    public class Account
    {
        
        public Account()
        {
        }
        public bool Login()
        {
            System.Console.Write("введите логин: ");
            string? login = Console.ReadLine();
            System.Console.Write("введите пароль:");
            string? pass = Console.ReadLine();
            return Search(login, pass);
        }

        private bool Search(string? login, string? pass)
        {
            string[] Lines = File.ReadAllLines(@"D:\ДЗ С#\hschool\hschool_beggining_csh\Game\User\DataBase\DT.txt");
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                Console.WriteLine("ERROR");
                return false;
            }
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] strings = Lines[i].Split(',');
                if (strings[0] == login && strings[1] == pass)
                {
                    Console.WriteLine("Login Succesful");
                    return true;
                }
            }
            System.Console.WriteLine("ERROR input");
            return false;
        }
        public bool Registr()
        {
            System.Console.WriteLine("введите логин");
            string? name = Console.ReadLine();
            System.Console.WriteLine("введите пароль");
            string? pass = Console.ReadLine();

            if (SearchSimple(name, pass))
            {
                File.AppendAllText(@"D:\ДЗ С#\hschool\hschool_beggining_csh\Game\User\DataBase\DT.txt", $"\n{name},{pass}");
                Console.WriteLine("Регистрация завершена");
            }
            return Login();
        }
        private bool SearchSimple(string? name, string? password)
        {
            string[] Lines = File.ReadAllLines(@"D:\ДЗ С#\hschool\hschool_beggining_csh\Game\User\DataBase\DT.txt");
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                System.Console.WriteLine("ERROR");
                return Registr();
            }
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] strings = Lines[i].Split(',');
                if (strings[0] == name)
                {
                    Console.WriteLine("такой пользователь уже существует");
                    return Registr();
                }
            }
            return true;
        }
    }
}
