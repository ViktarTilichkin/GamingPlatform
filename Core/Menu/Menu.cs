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

        public static void MenuStart(bool autorizationIn, string? numberMenu)
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
                    do
                    {
                        numberMenu = Console.ReadLine();
                    }
                    while (numberMenu != null);
                    if (numberMenu.Equals("1"))
                    {
                        while (true)
                        {
                            Console.WriteLine("Меню регистраци");
                            Console.WriteLine("1 регистрация");
                            Console.WriteLine("0 Выход");
                            numberMenu = Console.ReadLine();
                            if (numberMenu.Equals("1"))
                            {
                                autorizationIn = true;
                                // Console.WriteLine(data.Read());
                            }
                            else if (numberMenu.Equals("0"))
                            {
                                break;
                            }
                        }
                    }
                    else if (numberMenu.Equals("2"))
                    {
                        while (true)
                        {
                            Console.WriteLine("Меню регистрации");
                            Console.WriteLine("1 регестрация");
                            Console.WriteLine("0 Выход");
                            Console.WriteLine("Введите номер меню");
                            numberMenu = Console.ReadLine();
                            if (numberMenu.Equals("1"))
                            {
                                // вызываем класс авторизации и проверяем пользователя
                            }
                            else if (numberMenu.Equals("0"))
                            {
                                break;
                            }
                        }
                    }
                    else if (numberMenu.Equals("3"))
                    {
                        while (true)
                        {
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
                    while (true)
                    {
                        Console.WriteLine("Список доступных меню:");
                        Console.WriteLine("1 Просмотр статистики");
                        Console.WriteLine("2 Игра Крестики Нолики");
                        Console.WriteLine("3 Игра Не выбрал");
                        Console.WriteLine("0 Выход из Аккаунта");
                        Console.WriteLine("Введите номер меню");
                        numberMenu = Console.ReadLine();
                        if (numberMenu.Equals("1"))
                        {
                            // запрос на статистику

                        }
                        else if (numberMenu.Equals("2"))
                        {
                            // Вызов игры крестики нолики
                        }
                        else if (numberMenu.Equals("3"))
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
            Console.WriteLine("hello");
        }
    }
}