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
    private bool _SideToPlayerX = true;
    private char _SideToPlayer = 'X';
    private char _SideToBOT = 'O';
    private bool _PlayerVsBot = false;
    private XBOT BOT = new XBOT();
    private readonly string _coordErrorMessage = "Координаты должны быть: [0, 2]";

    public void StartGame(string userName, out string result)
    {
        result = null;
        Setting();
        Start(userName, out result);
    }
    public void Setting()
    {
        Console.Clear();
        Console.WriteLine("Let's set up the game!");
        Console.WriteLine("Which side will you choose X or O");
        string numberMenu = Console.ReadLine();
        if (numberMenu.ToLower().Equals("x"))
        {
            Console.WriteLine("succes");
        }
        else if (numberMenu.ToLower().Equals("o"))
        {
            _SideToPlayerX = false;
            _SideToPlayer = 'O';
            _SideToBOT = 'X';
            Console.WriteLine("succes");
        }
        Console.WriteLine("Are we playing with a friend or a bot? Y (friend) / N (bot)");
        numberMenu = Console.ReadLine();
        if (numberMenu.ToLower().Equals("y"))
        {
            Console.WriteLine("succes");
            _PlayerVsBot = true;
        }
        else if (numberMenu.ToLower().Equals("n"))
        {
            Console.WriteLine("succes");
        }
        Thread.Sleep(1000);
    }
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
            if (_isXMove)
            {
                if (_SideToPlayerX)
                {
                    if (!int.TryParse(Console.ReadLine(), out int fild))
                    {
                        ShowError(_coordErrorMessage);
                        continue;
                    }
                    if (fild == -1) break;
                    (row, col) = SwitchFild(fild);
                }
                else if (_PlayerVsBot)
                {
                    if (!int.TryParse(Console.ReadLine(), out int fild))
                    {
                        ShowError(_coordErrorMessage);
                        continue;
                    }
                    if (fild == -1) break;
                    (row, col) = SwitchFild(fild);
                }
                else
                {
                    Thread.Sleep(3000);
                    (row, col) = BOT.MakeComputerMove(_field, _SideToPlayer);
                }
            }
            else
            {
                if (!_SideToPlayerX)
                {
                    if (!int.TryParse(Console.ReadLine(), out int fild))
                    {
                        ShowError(_coordErrorMessage);
                        continue;
                    }
                    if (fild == -1) break;
                    (row, col) = SwitchFild(fild);
                }
                else if (_PlayerVsBot)
                {
                    if (!int.TryParse(Console.ReadLine(), out int fild))
                    {
                        ShowError(_coordErrorMessage);
                        continue;
                    }
                    if (fild == -1) break;
                    (row, col) = SwitchFild(fild);
                }
                else
                {
                    Thread.Sleep(3000);
                    (row, col) = BOT.MakeComputerMove(_field, _SideToPlayer);
                }
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
                    return EndGame("Крестики", !IsWinner('X'));

                }
                else if (IsWinner('O'))
                {
                    Draw();
                    result = "XO game, You side X, Lose";
                    return EndGame("Нолики", !IsWinner('O'));
                }
                else if (!DrawGame())
                {
                    Draw();
                    result = "You have tied!";
                    return EndGame("Нолики", !DrawGame());
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
    private bool DrawGame()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_field[i, j] != 'O' && _field[i, j] != 'X')
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void ClearField()
    {
        _field = new char[3, 3] {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' },
            };
    }

    private bool EndGame(string player, bool resultGame)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        if (resultGame) Console.WriteLine(string.Format("\n Ничья!", player));
        else Console.WriteLine(string.Format("\n Победили {0}!", player));
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
    private (int, int) SwitchFild(int fild)
    {
        int row = -1;
        int col = -1;
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
        return (row, col);
    }
    //private void InputStep(out int fild)
    //{
    //    string input = Console.ReadLine();
    //    if (!int.TryParse(input, out  fild))
    //    {
    //        ShowError(_coordErrorMessage);
    //        continue;
    //    }
    //    if (fild == -1) break;
    //}
}
