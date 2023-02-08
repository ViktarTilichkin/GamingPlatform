using System;
using System.Security.Principal;
using Core.Repository;
using Core.Models;
using Core.Repositories;

namespace GamingDesktopApp;
internal class Program
{
    static void Main(string[] args)
    {
        //Account users = new Account();
        //User? user = null;
        //string? menu = "";
        //RepositoryData data = new RepositoryData();
        UserRepository data2 = new UserRepository();
        //data2.GetAll();
        Console.WriteLine(data2.Login("admin", "1234"));
        Console.WriteLine("hello");
        User user = new User(2, "poluadmin", "1234");
        Console.WriteLine(data2.Create(user));
        User user1 = new User(3, "poluadmin2", "1234");
        Console.WriteLine(data2.Create(user1));
        User user2 = new User(4, "poluadmin3", "1234");
        Console.WriteLine(data2.Create(user2));
        Console.WriteLine("wrongcreate");
        User user4 = new User(5, "poluadmin3", "1234");
        Console.WriteLine(data2.Create(user4));
        List<User> test = data2.GetAll();
        foreach (var item in test)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("login");
        Console.WriteLine(data2.Login("poluadmin2", "1234"));
        Console.WriteLine("login");
        Console.WriteLine(data2.Login("www2", "1234"));
        Console.WriteLine("delete");
        Console.WriteLine(data2.Delete(user2));
        Console.WriteLine("delete end");
        test = data2.GetAll();
        foreach (var item in test)
        {
            Console.WriteLine(item);
        }
        //while (true)
        //{
        //    if (!autorizationIn)
        //    {
        //        Console.WriteLine("Список доступных меню:");
        //        Console.WriteLine("1 Регистраация");
        //        Console.WriteLine("2 Авторизация");
        //        Console.WriteLine("3 Игры");
        //        Console.WriteLine("0 Выход из программы");
        //        Console.WriteLine("Введите номер меню");
        //        menu = Console.ReadLine();
        //        if (menu.Equals("1"))
        //        {
        //            while (true)
        //            {
        //                Console.WriteLine("Меню регистраци");
        //                Console.WriteLine("1 регистрация");
        //                Console.WriteLine("0 Выход");
        //                menu = Console.ReadLine();
        //                if (menu.Equals("1"))
        //                {
        //                    Console.WriteLine(data.Read());
        //                }
        //                else if (menu.Equals("0"))
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //        else if (menu.Equals("2"))
        //        {
        //            while (true)
        //            {
        //                Console.WriteLine("Меню регистрации");
        //                Console.WriteLine("1 регестрация");
        //                Console.WriteLine("0 Выход");
        //                Console.WriteLine("Введите номер меню");
        //                menu = Console.ReadLine();
        //                if (menu.Equals("1"))
        //                {
        //                    // вызываем класс авторизации и проверяем пользователя
        //                }
        //                else if (menu.Equals("0"))
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //        else if (menu.Equals("3"))
        //        {
        //            while (true)
        //            {
        //                Console.WriteLine("Статистика по играм");
        //                Console.WriteLine("1 крестики нолики");
        //                Console.WriteLine("еще игра");
        //                Console.WriteLine("0 Выход");
        //                menu = Console.ReadLine();
        //                if (menu.Equals("1"))
        //                {
        //                    // статистика игре
        //                }
        //                if (menu.Equals("2"))
        //                {
        //                    // статистика игре
        //                }
        //                else if (menu.Equals("0"))
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    else if (autorizationIn)
        //    {
        //        while (true)
        //        {
        //            Console.WriteLine("Список доступных меню:");
        //            Console.WriteLine("1 Просмотр статистики");
        //            Console.WriteLine("2 Игра Крестики Нолики");
        //            Console.WriteLine("3 Игра Не выбрал");
        //            Console.WriteLine("0 Выход из Аккаунта");
        //            Console.WriteLine("Введите номер меню");
        //            menu = Console.ReadLine();
        //            if (menu.Equals("1"))
        //            {
        //                // запрос на статистику

        //            }
        //            else if (menu.Equals("2"))
        //            {
        //                // Вызов игры крестики нолики
        //            }
        //            else if (menu.Equals("3"))
        //            {
        //                // вызов игры 
        //            }
        //            else if (menu.Equals("0"))
        //            {
        //                break;
        //            }
        //        }
        //    }
        //    else if (menu.Equals("0"))
        //    {
        //        break;
        //    }
        //}
    }
}