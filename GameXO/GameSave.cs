using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameXO
{
    public class GameSave
    {
        protected string path { get; } = AppDomain.CurrentDomain.BaseDirectory + "save.txt";
        private char[,] _fieldDefault = new char[3, 3] {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' },
            };
        private EmulationGame game = new EmulationGame();
        public GameSave()
        { }
        public GameSave(char[,] board, bool isXmove, bool playerVsBot, char playerSide, int playerId)
        {
            ConvertFieldToRow(board);
            game.isXMove = isXmove;
            game.PlayerVsBot = playerVsBot;
            game.SideToPlayer = playerSide;
            game.PlaeyrId = playerId;
        }

        public void SaveGame(int playerId)
        {
            List<EmulationGame> gamesave = new List<EmulationGame>();
            EmulationGame save = new EmulationGame();
            StreamReader reader = new StreamReader("save.txt");
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var fild = JsonSerializer.Deserialize<EmulationGame>(line, serializeoptions);
                    if (fild.PlaeyrId != playerId)
                    {
                        gamesave.Add(fild);
                    }
                    line = reader.ReadLine();
                };
            }
            reader.Close();
            gamesave.Add(game);
            foreach (EmulationGame game in gamesave)
            {
                Console.WriteLine(game.ToString());
                Console.ReadLine();
            }
            StreamWriter sw1 = new StreamWriter(path);
            foreach (EmulationGame item in gamesave)
            {
                string json = JsonSerializer.Serialize(item, serializeoptions);
                sw1.WriteLine(json);
            }
            sw1.Close();
        }

        public (char[,], bool, bool, char, bool) LoadGame(int playerId, out bool load)
        {
            load = false;
            bool foundSave = false;
            if (File.Exists("save.txt"))
            {
                List<EmulationGame> gamesave = new List<EmulationGame>();
                EmulationGame save = new EmulationGame();
                StreamReader reader = new StreamReader("save.txt");
                var serializeoptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        var fild = JsonSerializer.Deserialize<EmulationGame>(line, serializeoptions);
                        gamesave.Add(fild);
                        line = reader.ReadLine();
                    };
                    foreach (EmulationGame user in gamesave)
                    {
                        if (user.PlaeyrId == playerId)
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
                        ConvertFieldToBoard(save.fieldROW1, save.fieldROW2, save.fieldROW3, out char[,] board);
                        save.SideToPlayer = save.SideToPlayerX ? 'X' : 'O';
                        Console.WriteLine($"Игра игрока с id {playerId} загружена ");
                        Thread.Sleep(1500);
                        Console.WriteLine(save.SideToPlayer);
                        Console.ReadKey();
                        load = true;
                        return (board, save.isXMove, save.SideToPlayerX, save.SideToPlayer, save.PlayerVsBot);
                    }
                }
                else
                {
                    Console.WriteLine($"Игра игрока с id {playerId} не найдена");
                }

            }
            return (_fieldDefault, default, default, default, default);
        }
        private void ConvertFieldToRow(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (row == 0) game.fieldROW1[col] = board[row, col];
                    if (row == 1) game.fieldROW2[col] = board[row, col];
                    if (row == 2) game.fieldROW3[col] = board[row, col];
                }
                Console.WriteLine(game.fieldROW1[row]);
            }
        }
        private void ConvertFieldToBoard(char[] row1, char[] row2, char[] row3, out char[,] board)
        {
            board = new char[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (row == 0) board[row, col] = row1[col];
                    if (row == 1) board[row, col] = row2[col];
                    if (row == 2) board[row, col] = row3[col];
                }
            }
        }
    }
}
