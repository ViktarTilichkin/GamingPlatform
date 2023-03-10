namespace GameBak_Dice
{
    //     Инвентарь
    //      3 игровые кости на каждого игрока
    //      Правила
    //      Чтобы определить кто из игроков сделает первый ход, каждый участник бросает три кости.
    //        Право первого хода получает тот, кто набрал наибольшее число очков.Тот, кто набрал меньше всего очков, бросает одну кость, чтобы определить число, которое в игре называется очком.
    //    Процесс игры в бак-дайс выглядит следующим образом: игроки по очереди бросают кости так, чтобы на них выпало число, которое было определено перед началом игры – то есть очко.
    //    Каждое очко, которое выпадает, засчитывается игроку, если же очко не выпало, то ход переходит сопернику.
    //    Цель игроков – набрать 15 баллов (бак), то есть 15 раз выбросить очко.По достижению этой отметки игрок выбывает из игры, становясь наблюдателем за оставшимися участниками.
    //    Тот игрок, который не смог собрать бак, считается проигравшим и выплачивает выигрыш победителям – всем игрокам, которые вышли из игры, собрав бак. Учитывая большое количество
    //    победителей и всего одного проигравшего, сумму выигрыша принято оговаривать заранее.
    //    В бак-дайс игрок может выиграть мгновенно.Для этого ему необходимо, чтобы выпал «большой бак» – комбинация из трех заранее определенных очков. В этом случае игрок сразу
    //    выбывает из игры, ведь большой бак учитывается как 15 очков, независимо от текущего положения участника в игре.Также предусмотрен так называемый «малый бак» – комбинация
    //    из трех любых одинаковых чисел, кроме цифры-очка.В этом случае игроку зачисляется сразу 5 очков и предоставляется право еще одного хода.

    // Enum для списка имен ботов. пользователей собираем в лист и ботов формируем в лист. лист сортируем по случайному броску от большего к меньшему. затем игрок с наименьшем числом кидает
    // одну кость и получаем число бак. Затем идем по отсортированому листу давая каждому игроку ход. если он набрал 15 пропускаем и считаем его выйгрывшем.
    // настройки игрок, колчиство игроков друзей (имена) , колчиство ботов. Кости живые игроки кидают релаьные или вертуальные.

    public class BakDice
    {
        public List<Player> playerList = new List<Player>();
        public int PlayerId { get; set; }
        public int ValuesFrend { get; set; }
        public int ValuesBot { get; set; }
        public int Bak = 4;
        public string PlayerName { get; set; }
        public bool Dice = false;
        public bool Load = false;
        public bool StopGame = true;
        public GameSave save = new GameSave();

        public void StartGame(int id, string name, out string result)
        {
            Console.WriteLine(id);
            (playerList, PlayerId, ValuesFrend, ValuesBot, Bak, PlayerName, Dice) = save.LoadGame(id, out bool load);
            if (!load)
            {
                playerList = new List<Player>();
                PlayerId = id;
                PlayerName = name;
                Load = load;
                Setting();
                CreatePlayers();
            }
            result = null;
            Game();
        }

        public void Game()
        {
            int dice1 = default;
            int dice2 = default;
            int dice3 = default;
            string name = default;
            Console.Clear();
            ShowFild();
            if (!Load) FirstMove();
            Console.Clear();
            ShowFild();
            while (StopGame)
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    var lose = playerList.Where(x => x.Bak < 15);
                    if (lose.Count() == 1)
                    {
                        Console.WriteLine($"You lose {lose.ElementAt(0)}");
                        Console.ReadKey();
                    }
                    if (playerList[i].Bak >= 15)
                    {
                        playerList[i].Bak = 15;
                        continue;
                    }
                    name = playerList[i].Name;
                    if (Dice)
                    {
                        dice1 = RealDice();
                        dice2 = RealDice();
                        dice3 = RealDice();
                    }
                    else
                    {
                        dice1 = RandomDice();
                        dice2 = RandomDice();
                        dice3 = RandomDice();
                    }
                    if (dice1 == Bak && dice2 == Bak && dice3 == Bak)
                    {
                        playerList[i].Bak = 15;
                    }
                    else if (dice1 == dice2 && dice1 == dice3)
                    {
                        playerList[i].Bak += 5;
                    }
                    else if (dice1 == Bak || dice2 == Bak || dice3 == Bak)
                    {
                        playerList[i].Bak += 1;
                    }

                    Console.Clear();
                    ShowFild();
                    Console.WriteLine();
                    Console.WriteLine($"Move {name}");
                    Console.WriteLine($"{dice1} {dice2} {dice3}");
                    Console.WriteLine();
                    save = new GameSave(playerList, PlayerId, ValuesFrend, ValuesBot, Bak, PlayerName, Dice);
                    save.SaveGame(PlayerId);
                    Console.WriteLine($"press the button to continue or -1 to exit");
                    string menu = Console.ReadLine();
                    if (menu.Equals("-1"))
                    {
                        StopGame = false;
                        break;
                    }
                }
            }
        }

        public void Setting()
        {
            Console.Clear();
            Console.WriteLine("Let's set up the game!");
            Console.WriteLine("How many of your friends will play?");
            string value = Console.ReadLine();
            if (int.TryParse(value, out int valueFriend))
            {
                if (valueFriend >= 0)
                {
                    ValuesFrend = valueFriend;
                }
                else
                {
                    Console.WriteLine("please read the condition");
                }
            }
            Console.WriteLine("How many of Bot will play?");
            value = Console.ReadLine();
            if (int.TryParse(value, out int valueBOT))
            {
                if (valueBOT >= 0)
                {
                    ValuesBot = valueBOT;
                }
                else
                {
                    Console.WriteLine("please read the condition");
                }
            }
            Console.WriteLine("Are we playing with real dice or computer dice? Y(real dice) / N (computer dice)");
            string numberMenu = Console.ReadLine();
            if (numberMenu.ToLower().Equals("y"))
            {
                Dice = true;
                Console.WriteLine("succes");
                Thread.Sleep(1000);
            }
            else if (numberMenu.ToLower().Equals("n"))
            {
                Console.WriteLine("succes");
            }
            Thread.Sleep(1000);
        }
        private void ShowFild()
        {
            Console.WriteLine();
            Console.WriteLine($"Hello, {PlayerName}");
            Console.WriteLine();
            Console.WriteLine($"Bak it {Bak}");
            Console.WriteLine();
            foreach (Player player in playerList)
            {
                Console.WriteLine(player);
            }
        }

        private void CreatePlayers()
        {
            Player player = new Player();
            string name = "";
            Random rnd = new Random();
            for (int i = 0; i < ValuesFrend; i++)
            {
                player = new Player();
                Console.Write($"Enter the player's name {i + 1} : ");
                name = Console.ReadLine();
                player.Name = name;
                Console.WriteLine(player);
                playerList.Add(player);
            }
            for (int j = 0; j < ValuesBot; j++)
            {
                player = new Player();
                player.Name = ((NameBot)rnd.Next(1, 14)).ToString();
                playerList.Add(player);
            }
        }
        private int RandomDice()
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, 6);
            Console.WriteLine($"Dice value: {dice}");
            return dice;
        }
        private int RealDice()
        {
            Console.Write("Dice value: ");
            do
            {
                string number = Console.ReadLine();
                if (int.TryParse(number, out int num))
                {
                    if (num > 0 && num <= 6)
                    {
                        return num;
                    }
                }
            }
            while (true);
        }
        private void FirstMove()
        {
            int dice = default;
            for (int i = 0; i < playerList.Count; i++)
            {
                Console.WriteLine($"Move {playerList[i].Name}");
                for (int j = 0; j < 3; j++)
                {
                    if (Dice)
                    {
                        dice = RealDice();
                        playerList[i].LastDice += dice;
                    }
                    else
                    {
                        dice = RandomDice();
                        playerList[i].LastDice += dice;
                    }
                }
                Console.Write($"Total: {playerList[i].LastDice}");
                Console.WriteLine();
            }
            Comparison<Player> comparison = (a, b) =>
            {
                int result = b.LastDice - a.LastDice;
                return result;
            };
            playerList.Sort(comparison);
            Console.WriteLine($"The player {playerList[playerList.Count - 1].Name} will determine the number Bak");
            if (Dice)
            {
                Bak = RealDice();
            }
            else
            {
                Bak = RandomDice();
            }
            Console.WriteLine($"Bak it {Bak}");
        }
    }
}




