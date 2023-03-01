using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXO
{
    public class GameSave
    {
        private char[,] board = new char[3, 3];
        private bool _isXmove = true;
        private bool _PlayerVsBot = false;
        private char _SideToPlayer = 'X';
        private int playerId = -1;

        public GameSave(char[,] board, bool isXmove, bool playerVsBot, char playerSide, int playerId)
        {
            this.board = board;
            this._isXmove = isXmove;
            this._PlayerVsBot = playerVsBot;
            this._SideToPlayer = playerSide;
            this.playerId = playerId;
        }

        public void SaveGame()
        {
            StreamWriter writer = new StreamWriter("gamesave.txt", true);
            writer.WriteLine(playerId);
            writer.WriteLine(_isXmove);
            writer.WriteLine(_PlayerVsBot);
            writer.WriteLine(_SideToPlayer);
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    writer.Write(board[row, col] + " ");
                }
                writer.WriteLine();
            }
            writer.Close();
            Console.WriteLine($"Игра игрока с id {playerId} сохранена в файле gamesave.txt.");
        }

        public void LoadGame(int playerId)
        {
            this.playerId = playerId;
            bool foundSave = false;

            if (File.Exists("gamesave.txt"))
            {
                StreamReader reader = new StreamReader("gamesave.txt");
                while (!reader.EndOfStream)
                {
                    int id = Convert.ToInt32(reader.ReadLine());
                    if (id == playerId)
                    {
                        foundSave = true;
                        _isXmove = Convert.ToBoolean(reader.ReadLine());
                        _PlayerVsBot = Convert.ToBoolean(reader.ReadLine());
                        _SideToPlayer = reader.ReadLine();
                        for (int row = 0; row < 3; row++)
                        {
                            string[] line = reader.ReadLine().Split(' ');
                            for (int col = 0; col < 3; col++)
                            {
                                board[row, col] = line[col];
                            }
                        }
                        Console.WriteLine($"Игра игрока с id {playerId} загружена из файла gamesave.txt.");
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            reader.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
