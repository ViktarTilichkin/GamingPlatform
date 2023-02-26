using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXO
{
    public class GameSave
    {
        private string[,] board = new string[3, 3]; // игровое поле
        private bool isPlayerX = true; // чей сейчас ход (true - крестики, false - нолики)
        private bool isAgainstComputer = false; // игра против компьютера
        private string playerSide = "X"; // какую сторону выбрал игрок ("X" или "O")
        private int playerId = -1; // идентификатор игрока

        public void SaveGame()
        {
            // открываем файл для записи
            StreamWriter writer = new StreamWriter("gamesave.txt", true);

            // записываем настройки игры в файл
            writer.WriteLine(playerId);
            writer.WriteLine(isPlayerX);
            writer.WriteLine(isAgainstComputer);
            writer.WriteLine(playerSide);

            // записываем состояние игрового поля в файл
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    writer.Write(board[row, col] + " ");
                }
                writer.WriteLine();
            }

            // закрываем файл
            writer.Close();

            Console.WriteLine($"Игра игрока с id {playerId} сохранена в файле gamesave.txt.");
        }

        public void LoadGame(int playerId)
        {
            this.playerId = playerId;
            bool foundSave = false;

            if (File.Exists("gamesave.txt"))
            {
                // открываем файл для чтения
                StreamReader reader = new StreamReader("gamesave.txt");

                // читаем каждую запись в файле
                while (!reader.EndOfStream)
                {
                    // читаем идентификатор игрока из файла
                    int id = Convert.ToInt32(reader.ReadLine());

                    // если это запись для нужного игрока, то загружаем игру
                    if (id == playerId)
                    {
                        foundSave = true;

                        // читаем настройки игры из файла
                        isPlayerX = Convert.ToBoolean(reader.ReadLine());
                        isAgainstComputer = Convert.ToBoolean(reader.ReadLine());
                        playerSide = reader.ReadLine();

                        // читаем состояние игрового поля из файла
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
                        // пропускаем запись для другого игрока
                        for (int i = 0; i < 10; i++)
                        {
                            reader.ReadLine();
                        }
                    }
                }

                // закрываем файл

            }
        }
    }
}
