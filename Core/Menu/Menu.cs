using Core.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Controller;
using Core.Models;
using Games.Core;


namespace Core.Menu
{
    public static class Menu
    {
        public static void MenuStart(bool autorizationIn, string? numberMenu, User? user)
        {
            string gameResult = "";
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
                            Console.WriteLine("1 статистика игр");
                            Console.WriteLine("2 список доступных игры и правила игры");
                            Console.WriteLine("0 Выход");
                            numberMenu = Console.ReadLine();
                            if (numberMenu.Equals("1"))
                            {
                                UserStatsController stats = new UserStatsController();
                                stats.GetAllStats();
                                Console.ReadKey();
                            }
                            if (numberMenu.Equals("2"))
                            {
                                Console.WriteLine("крестики нолики");
                                Console.WriteLine();
                                Console.WriteLine("Правила игры\r\nИгроки по очереди ставят на свободные клетки поля 3×3 знаки (один всегда крестики, другой всегда нолики)." +
                                    " \r\nПервый, выстроивший в ряд 3 своих фигуры по вертикали, горизонтали или большой диагонали, выигрывает.\r\n");
                                Console.WriteLine("BAK DICE");
                                Console.WriteLine();
                                Console.WriteLine("Инвентарь\r\n3 игровые кости на каждого игрока\r\nПравила\r\nЧтобы определить кто из игроков сделает первый ход, каждый участник бросает три кости. " +
                                    "Право первого хода получает тот, кто набрал наибольшее число очков. Тот, кто набрал меньше всего очков, бросает одну кость, чтобы определить число, которое в игре называется очком." +
                                    "\r\n\r\nПроцесс игры в бак-дайс выглядит следующим образом: игроки по очереди бросают кости так, чтобы на них выпало число, которое было определено перед началом игры – то есть очко." +
                                    " Каждое очко, которое выпадает, засчитывается игроку, если же очко не выпало, то ход переходит сопернику.\r\n\r\nЦель игроков – набрать 15 баллов (бак), то есть 15 раз выбросить очко." +
                                    " По достижению этой отметки игрок выбывает из игры, становясь наблюдателем за оставшимися участниками. Тот игрок, который не смог собрать бак, считается проигравшим и выплачивает выигрыш " +
                                    "победителям – всем игрокам, которые вышли из игры, собрав бак. Учитывая большое количество победителей и всего одного проигравшего, сумму выигрыша принято оговаривать заранее." +
                                    "\r\n\r\nВ бак-дайс игрок может выиграть мгновенно. Для этого ему необходимо, чтобы выпал «большой бак» – комбинация из трех заранее определенных очков. В этом случае игрок сразу выбывает" +
                                    " из игры, ведь большой бак учитывается как 15 очков, независимо от текущего положения участника в игре. Также предусмотрен так называемый «малый бак» – комбинация из трех любых одинаковых" +
                                    " чисел, кроме цифры-очка. В этом случае игроку зачисляется сразу 5 очков и предоставляется право еще одного хода.");
                                Console.WriteLine();
                                Console.WriteLine("press the button to exit");
                                Console.ReadKey();
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
                        Console.WriteLine("3 Игры");
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
                            UserStatsController stats = new UserStatsController();
                            stats.GetUserStat(user);
                            Console.ReadKey();
                        }
                        else if (numberMenu.Equals("3"))
                        {
                            GamesCore newGame = new GamesCore(user.Id);
                            newGame.MenuGames(user.Id, user.Name, out gameResult);
                            UserStatsController stats = new UserStatsController();
                            stats.AddUserStat(user, gameResult);
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