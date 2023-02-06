using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Repository;

namespace Core
{
    //public class Account
    //{
    //    private RepositoryData Repositor = new RepositoryData();

    //    public bool Login()
    //    {
    //        System.Console.Write("введите логин: ");
    //        string? login = Console.ReadLine();
    //        System.Console.Write("введите пароль:");
    //        string? pass = Console.ReadLine();
    //        return Repositor.Read(login, pass);
    //    }

    //    public bool Registr()
    //    {
    //        System.Console.WriteLine("введите логин");
    //        string? name = Console.ReadLine();
    //        System.Console.WriteLine("введите пароль");
    //        string? pass = Console.ReadLine();

    //        if (SearchSimple(name, pass))
    //        {
    //            File.AppendAllText(@"~\Data.txt", $"\n{name},{pass}", true);
    //            Console.WriteLine("Регистрация завершена");
    //        }
    //        return Login();
    //    }
    //    private bool SearchSimple(string? name, string? password)
    //    {
    //        string[] Lines = File.ReadAllLines(@"..\GamingPlatform\Core\Data.txt");
    //        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
    //        {
    //            System.Console.WriteLine("ERROR");
    //            return Registr();
    //        }
    //        for (int i = 0; i < Lines.Length; i++)
    //        {
    //            string[] strings = Lines[i].Split(',');
    //            if (strings[0] == name)
    //            {
    //                Console.WriteLine("такой пользователь уже существует");
    //                return Registr();
    //            }
    //        }
    //        return true;
    //    }
    //}
}
