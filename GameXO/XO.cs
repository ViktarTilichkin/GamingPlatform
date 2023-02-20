using System.Numerics;

namespace GameXO;
public class XO
{
    private char[,] _field = new char[3, 3] {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' },
            };
    private string _name;
    private bool _isXMove = true;
    private readonly string _coordErrorMessage = "Координаты должны быть: [0, 2]";

    public void Start(string userName, out string result)
    {
        _name = userName;
        result = null;
        Draw();

        int row = -1;
        int col = -1;
        do
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n Введите номер ячейки: \n (или -1 для выхода): ");
            Console.ForegroundColor = ConsoleColor.White;
            if (!int.TryParse(Console.ReadLine(), out int fild))
            {
                ShowError(_coordErrorMessage);
                continue;
            }
            if (fild == -1) break;
            switch (fild)
            {
                case 1:
                    row = 0;
                    col = 0;
                    break;
                case 2:
                    row = 0;
                    col = 1;
                    break;
                case 3:
                    row = 0;
                    col = 2;
                    break;
                case 4:
                    row = 1;
                    col = 0;
                    break;
                case 5:
                    row = 1;
                    col = 1;
                    break;
                case 6:
                    row = 1;
                    col = 2;
                    break;
                case 7:
                    row = 2;
                    col = 0;
                    break;
                case 8:
                    row = 2;
                    col = 1;
                    break;
                case 9:
                    row = 2;
                    col = 2;
                    break;
            }
            if (!Update(row, col, out result))
            {
                break;
            }
            Draw();
        } while (true);

    }

    private bool Update(int row, int col, out string result)
    {
        if (row == -1 || col == -1)
        {
            result = null;
            return true;
        }

        if (0 <= row && row <= 2 &&
            0 <= col && col <= 2)
        {
            if (_field[row, col] != 'X' && _field[row, col] != 'O')
            {
                _field[row, col] = _isXMove ? 'X' : 'O';

                if (IsWinner('X'))
                {
                    result = "XO game, You side X, Win";
                    Draw();
                    return EndGame("Крестики");

                }
                else if (IsWinner('O'))
                {
                    Draw();
                    result = "XO game, You side X, Lose";
                    return EndGame("Нолики");
                }

                _isXMove = !_isXMove;
                result = null;
                return true;
            }
            else
            {
                ShowError("По этим координатам уже сделан ход.");
                result = null;
                return true;
            }
        }
        else
        {
            ShowError(_coordErrorMessage);
            result = null;
            return true;
        }
    }

    private void Draw()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n Hello {_name}!\n");
        Console.WriteLine("\n Крестики-Нолики\n");
        Console.ForegroundColor = ConsoleColor.Magenta;

        ShowField();

        // Устанавливаем цвет рисования белым
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void ShowField()
    {
        Console.WriteLine(string.Format("  {0} | {1} | {2}", _field[0, 0], _field[0, 1], _field[0, 2]));
        Console.WriteLine(" ---+---+---");
        Console.WriteLine(string.Format("  {0} | {1} | {2}", _field[1, 0], _field[1, 1], _field[1, 2]));
        Console.WriteLine(" ---+---+---");
        Console.WriteLine(string.Format("  {0} | {1} | {2}", _field[2, 0], _field[2, 1], _field[2, 2]));
    }

    private void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n " + message);
        Console.WriteLine(" Нажмите любую клавишу");

        Console.ReadKey();
    }

    private bool IsWinner(char player)
    {
        return (
            // Rows
            (_field[0, 0] == player && _field[0, 1] == player && _field[0, 2] == player) ||
            (_field[1, 0] == player && _field[1, 1] == player && _field[1, 2] == player) ||
            (_field[2, 0] == player && _field[2, 1] == player && _field[2, 2] == player) ||
            // Columns
            (_field[0, 0] == player && _field[1, 0] == player && _field[2, 0] == player) ||
            (_field[0, 1] == player && _field[1, 1] == player && _field[2, 1] == player) ||
            (_field[0, 2] == player && _field[1, 2] == player && _field[2, 2] == player) ||
            // Diagonals
            (_field[0, 0] == player && _field[1, 1] == player && _field[2, 2] == player) ||
            (_field[0, 2] == player && _field[1, 1] == player && _field[2, 0] == player)
        );
    }

    private void ClearField()
    {
        _field = new char[3, 3] {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' },
            };
    }

    private bool EndGame(string player)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(string.Format("\n Победили {0}!", player));
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n Нажмите любую клавишу для продолжения");
        if (Convert.ToString(Console.ReadLine()).ToLower().Equals("n"))
        {
            return false;
        }
        Console.ReadKey();
        ClearField();
        return true;
    }

    //private void AIUpdate(string aiSide)
    //{

    //    if (0 <= row && row <= 2 &&
    //        0 <= col && col <= 2)
    //    {
    //        if (_field[row, col] != 'X' && _field[row, col] != 'O')
    //        {
    //            _field[row, col] = _isXMove ? 'X' : 'O';

    //            if (IsWinner('X'))
    //            {
    //                Draw();
    //                EndGame("Крестики");
    //            }
    //            else if (IsWinner('O'))
    //            {
    //                Draw();
    //                EndGame("Нолики");
    //            }

    //            _isXMove = !_isXMove;
    //        }
    //        else
    //        {
    //            ShowError("По этим координатам уже сделан ход.");
    //        }
    //    }
    //    else
    //    {
    //        ShowError(_coordErrorMessage);
    //        return;
    //    }
    //}
    //private bool NextStepWin(char player)
    //{
    //    int countRows = 0;
    //    int countColumns = 0;
    //    int countDiagonals = 0;
    //    for (int i = 0; i < _field.Length; i++)
    //    {
    //        for (int j = 0; j < _field.Length; j++)
    //        {
    //            if (i == 0)
    //            {
    //                if (_field[i, j] == player)
    //                {
    //                    countRows++;
    //                }

    //            }
    //        }
    //    }
    //    return (
    //    // Rows
    //        (_field[0, 0] == player && _field[0, 1] == player && _field[0, 2] == player) ||
    //        (_field[1, 0] == player && _field[1, 1] == player && _field[1, 2] == player) ||
    //        (_field[2, 0] == player && _field[2, 1] == player && _field[2, 2] == player) ||
    //    // Columns
    //        (_field[0, 0] == player && _field[1, 0] == player && _field[2, 0] == player) ||
    //        (_field[0, 1] == player && _field[1, 1] == player && _field[2, 1] == player) ||
    //        (_field[0, 2] == player && _field[1, 2] == player && _field[2, 2] == player) ||
    //    // Diagonals
    //        (_field[0, 0] == player && _field[1, 1] == player && _field[2, 2] == player) ||
    //        (_field[0, 2] == player && _field[1, 1] == player && _field[2, 0] == player)
    //    );
    //}
}
