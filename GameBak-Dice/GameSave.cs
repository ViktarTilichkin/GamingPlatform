using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using Newtonsoft.Json;

namespace GameBak_Dice
{
    public class GameSave
    {
        protected string path { get; } = AppDomain.CurrentDomain.BaseDirectory + "saveBakDice.txt";

        private EmulationGame game = new EmulationGame();
        public GameSave()
        { }
        public GameSave(List<Player> players, int playerid, int valuefrend, int valuebot, int bak, string playerName, bool dice)
        {
            game.playerList = players;
            game.PlayerId = playerid;
            game.ValuesFrend = valuefrend;
            game.ValuesBot = valuebot;
            game.Bak = bak;
            game.PlayerName = playerName;
            game.Dice = dice;
        }

        public void SaveGame(int playerId)
        {
            List<EmulationGame> gamesave = new List<EmulationGame>();
            EmulationGame save = new EmulationGame();
            StreamReader reader = new StreamReader("saveBakDice.txt");
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var fild = JsonSerializer.Deserialize<EmulationGame>(line);
                    if (fild.PlayerId != playerId)
                    {
                        gamesave.Add(fild);
                    }
                    line = reader.ReadLine();
                };
            }
            reader.Close();
            gamesave.Add(game);
            StreamWriter sw1 = new StreamWriter(path);
            foreach (EmulationGame item in gamesave)
            {
                string json = JsonSerializer.Serialize(item);
                sw1.WriteLine(json);
            }
            sw1.Close();
        }

        public (List<Player>, int, int, int, int, string, bool) LoadGame(int playerId, out bool load)
        {
            load = false;
            bool foundSave = false;
            if (File.Exists("saveBakDice.txt"))
            {
                List<EmulationGame> gamesave = new List<EmulationGame>();
                EmulationGame save = new EmulationGame();
                StreamReader reader = new StreamReader("saveBakDice.txt");
                var serializeoptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        var fild = JsonSerializer.Deserialize<EmulationGame>(line);
                        gamesave.Add(fild);
                        line = reader.ReadLine();
                    };
                    foreach (EmulationGame user in gamesave)
                    {
                        if (user.PlayerId == playerId)
                        {
                            save = user;
                            foundSave = true;
                        }
                    }
                }
                reader.Close();
                if (foundSave)
                {
                    Console.WriteLine("Save found, load? Y/n?");
                    if (Console.ReadLine().ToUpper().Equals("Y"))
                    {
                        Console.WriteLine("Great!");
                        Console.WriteLine($"Игра игрока с id {playerId} загружена ");
                        Thread.Sleep(1500);
                        Console.ReadKey();
                        load = true;
                        return (save.playerList, save.PlayerId, save.ValuesFrend, save.ValuesBot, save.Bak, save.PlayerName, save.Dice); ;
                    }
                }
                else
                {
                    Console.WriteLine($"Игра игрока с id {playerId} не найдена");
                }

            }
            return (null, default, default, default, default, default, default);
        }
    }
}
