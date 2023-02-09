using Core.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Menu
{
    public static class Menu
    {
        public static void Menu()
        {
            while (true)
            {
                if (!autorizationIn)
                {
                    Console.WriteLine("Список доступных меню:");
                    Console.WriteLine("1 Регистраация");
                    Console.WriteLine("2 Авторизация");
                    Console.WriteLine("3 Игры");
                    Console.WriteLine("0 Выход из программы");
                    Console.WriteLine("Введите номер меню");
                    muneStart()
                    menu = Console.ReadLine();
                    if (menu.Equals("1"))
                    {
                        while (true)
                        {
                            Console.WriteLine("Меню регистраци");
                            Console.WriteLine("1 регистрация");
                            Console.WriteLine("0 Выход");
                            menu = Console.ReadLine();
                            if (menu.Equals("1"))
                            {
                                Console.WriteLine(data.Read());
                            }
                            else if (menu.Equals("0"))
                            {
                                break;
                            }
                        }
                    }
                    else if (menu.Equals("2"))
                    {
                        while (true)
                        {
                            Console.WriteLine("Меню регистрации");
                            Console.WriteLine("1 регестрация");
                            Console.WriteLine("0 Выход");
                            Console.WriteLine("Введите номер меню");
                            menu = Console.ReadLine();
                            if (menu.Equals("1"))
                            {
                                // вызываем класс авторизации и проверяем пользователя
                            }
                            else if (menu.Equals("0"))
                            {
                                break;
                            }
                        }
                    }
                    else if (menu.Equals("3"))
                    {
                        while (true)
                        {
                            Console.WriteLine("Статистика по играм");
                            Console.WriteLine("1 крестики нолики");
                            Console.WriteLine("еще игра");
                            Console.WriteLine("0 Выход");
                            menu = Console.ReadLine();
                            if (menu.Equals("1"))
                            {
                                // статистика игре
                            }
                            if (menu.Equals("2"))
                            {
                                // статистика игре
                            }
                            else if (menu.Equals("0"))
                            {
                                break;
                            }
                        }
                    }
                }
                else if (autorizationIn)
                {
                    while (true)
                    {
                        Console.WriteLine("Список доступных меню:");
                        Console.WriteLine("1 Просмотр статистики");
                        Console.WriteLine("2 Игра Крестики Нолики");
                        Console.WriteLine("3 Игра Не выбрал");
                        Console.WriteLine("0 Выход из Аккаунта");
                        Console.WriteLine("Введите номер меню");
                        menu = Console.ReadLine();
                        if (menu.Equals("1"))
                        {
                            // запрос на статистику

                        }
                        else if (menu.Equals("2"))
                        {
                            // Вызов игры крестики нолики
                        }
                        else if (menu.Equals("3"))
                        {
                            // вызов игры 
                        }
                        else if (menu.Equals("0"))
                        {
                            break;
                        }
                    }
                }
                else if (menu.Equals("0"))
                {
                    break;
                }
            }
        }
    }
}