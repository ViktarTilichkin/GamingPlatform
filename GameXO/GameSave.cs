using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
        }

        public void LoadGame()
        {
            //this.playerId = playerId;
            //bool foundSave = false;

            //if (File.Exists("gamesave.txt"))
            //{
            //    StreamReader reader = new StreamReader("gamesave.txt");
            //    while (!reader.EndOfStream)
            //    {
            //        int id = Convert.ToInt32(reader.ReadLine());
            //        if (id == playerId)
            //        {
            //            foundSave = true;
            //            _isXmove = Convert.ToBoolean(reader.ReadLine());
            //            _PlayerVsBot = Convert.ToBoolean(reader.ReadLine());
            //            _SideToPlayer = reader.ReadLine();
            //            for (int row = 0; row < 3; row++)
            //            {
            //                string[] line = reader.ReadLine().Split(' ');
            //                for (int col = 0; col < 3; col++)
            //                {
            //                    board[row, col] = line[col];
            //                }
            //            }
            //            Console.WriteLine($"Игра игрока с id {playerId} загружена из файла gamesave.txt.");
            //            break;
            //        }
            //        else
            //        {
            //            for (int i = 0; i < 10; i++)
            //            {
            //                reader.ReadLine();
            //            }
            //        }
            //    }
            //}
            Console.WriteLine(path);
            Console.WriteLine(game);
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            StreamWriter sw1 = new StreamWriter(path);
            string json = JsonSerializer.Serialize<EmulationGame>(game, serializeoptions);
            sw1.WriteLine(json);
            sw1.Close();
            Console.WriteLine(json);
            Console.ReadKey();
        }
    }
}
