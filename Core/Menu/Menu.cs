using Core.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Controller;
using Core.Models;


namespace Core.Menu
{
    public static class Menu
    {
        public static void MenuStart(bool autorizationIn, string? numberMenu, User? user)
        {
            while (true)
            {
                Console.Clear();
                if (!autorizationIn)
                {
                    Console.Clear();
                    Console.WriteLine("Список доступных меню:");
                    Console.WriteLine("1 Регистраация");
                    Console.WriteLine("2 Авторизация");
                    Console.WriteLine("3 Игры");
                    Console.WriteLine("0 Выход из программы");
                    Console.WriteLine("Введите номер меню");
                    numberMenu = Console.ReadLine();
                    if (numberMenu.Equals("1"))
                    {
                        Console.Clear();
                        while (true)
                        {

                            PlatformController ControllerUser = new PlatformController();
                            (bool, User?) result = ControllerUser.Create();
                            autorizationIn = result.Item1;
                            user = result.Item2;
                            break;
                        }
                    }
                    else if (numberMenu.Equals("2"))
                    {
                        Console.Clear();
                        while (true)
                        {
                            Console.Clear();
                            PlatformController ControllerUser = new PlatformController();
                            (bool, User?) result = ControllerUser.Login();
                            autorizationIn = result.Item1;
                            user = result.Item2;
                            break;
                        }
                    }
                    else if (numberMenu.Equals("3"))
                    {
                        Console.Clear();
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Статистика по играм");
                            Console.WriteLine("1 крестики нолики");
                            Console.WriteLine("еще игра");
                            Console.WriteLine("0 Выход");
                            numberMenu = Console.ReadLine();
                            if (numberMenu.Equals("1"))
                            {
                                // статистика игре
                            }
                            if (numberMenu.Equals("2"))
                            {
                                // статистика игре
                            }
                            else if (numberMenu.Equals("0"))
                            {
                                break;
                            }
                        }
                    }
                }
                else if (autorizationIn)
                {
                    Console.Clear();
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"Hello {user.Name}");
                        Console.WriteLine("Список доступных меню:");
                        Console.WriteLine("1 Изменение аккаунта");
                        Console.WriteLine("2 Просмотр статистики");
                        Console.WriteLine("3 Игра Крестики Нолики");
                        Console.WriteLine("4 Игра Не выбрал");
                        Console.WriteLine("0 Выход из Аккаунта");
                        Console.WriteLine("Введите номер меню");
                        numberMenu = Console.ReadLine();
                        if (numberMenu.Equals("1"))
                        {
                            Console.Clear();
                            Console.WriteLine("1 Изменение пароля");
                            Console.WriteLine("2 Удаление аккаунта");
                            Console.WriteLine("0 выход");
                            numberMenu = Console.ReadLine();
                            if (numberMenu.Equals("1"))
                            {
                                PlatformController ControllerUser = new PlatformController();
                                (bool, User?) result = ControllerUser.Update(user);
                                autorizationIn = result.Item1;
                                user = result.Item2;
                            }
                            else if (numberMenu.Equals("2"))
                            {
                                PlatformController ControllerUser = new PlatformController();
                                (bool, User?) result = ControllerUser.Delete(user);
                                autorizationIn = result.Item1;
                                user = result.Item2;
                                break;
                            }

                        }
                        else if (numberMenu.Equals("2"))
                        {

                            // просмотр статистики
                        }
                        else if (numberMenu.Equals("3"))
                        {

                            // Вызов игры крестики нолики
                        }
                        else if (numberMenu.Equals("4"))
                        {

                            // вызов игры 
                        }
                        else if (numberMenu.Equals("0"))
                        {
                            autorizationIn = false;
                            break;
                        }
                    }
                }
                else if (numberMenu.Equals("0"))
                {
                    break;
                }
            }
        }
    }
}