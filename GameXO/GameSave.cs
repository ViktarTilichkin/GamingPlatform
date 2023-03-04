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

        public void SaveGame()
        {
            //StreamWriter writer = new StreamWriter("gamesave.txt", true);
            //writer.WriteLine(playerId);
            //writer.WriteLine(_isXmove);
            //writer.WriteLine(_PlayerVsBot);
            //writer.WriteLine(_SideToPlayer);
            //for (int row = 0; row < 3; row++)
            //{
            //    for (int col = 0; col < 3; col++)
            //    {
            //        writer.Write(board[row, col] + " ");
            //    }
            //    writer.WriteLine();
            //}
            //writer.Close();
            //Console.WriteLine($"Игра игрока с id {playerId} сохранена в файле gamesave.txt.");
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            StreamWriter sw1 = new StreamWriter(path);
            string json = JsonSerializer.Serialize(game, serializeoptions);
            sw1.WriteLine(json);
            sw1.Close();
        }

        public (char[,], bool, bool, char, bool) LoadGame(int playerId)
        {
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
                    if (foundSave)
                    {
                        ConvertFieldToBoard(save.fieldROW1, save.fieldROW2, save.fieldROW3, out char[,] board);
                        Console.WriteLine($"Игра игрока с id {playerId} загружена ");
                        return (board, save.isXMove, save.SideToPlayerX, save.SideToPlayer, save.PlayerVsBot);
                    }
                    else
                    {
                        Console.WriteLine($"Игра игрока с id {playerId} не найдена");
                    }
                }
            }
            return (default, default, default, default, default);
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
