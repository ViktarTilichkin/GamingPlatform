using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXO
{
    public class XBOT
    {
        private char[,] _fieldBOT = new char[3, 3] {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' },
            };
        public (int, int) MakeComputerMove(char[,] board, char playerSimbol)
        {
            CopyArray(board);
            bool isBlockingMove = false;
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_fieldBOT[i, j] != 'X' && _fieldBOT[i, j] != 'O')
                    {
                        _fieldBOT[i, j] = playerSimbol;
                        isBlockingMove = CheckForWinningMove(_fieldBOT, playerSimbol);
                        _fieldBOT[i, j] = board[i, j];
                        if (isBlockingMove)
                        {
                            return (i, j);
                        }
                    }
                }
            }
            int row = 0;
            int col = 0;
            while (true)
            {
                row = rnd.Next(0, 2);
                col = rnd.Next(0, 2);
                if (board[row, col] != 'X' && board[row, col] != 'O')
                {
                    break;
                }
            }
            return (row, col);
        }
        private static bool CheckForWinningMove(char[,] board, char symbol)
        {

            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == symbol && board[i, 1] == symbol && board[i, 2] == symbol) return true;
                if (board[0, i] == symbol && board[1, i] == symbol && board[2, i] == symbol) return true;
            }
            if (board[0, 0] == symbol && board[1, 1] == symbol && board[2, 2] == symbol) return true;
            if (board[0, 2] == symbol && board[1, 1] == symbol && board[2, 0] == symbol) return true;
            return false;
        }
        private bool CopyArray(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_fieldBOT[i, j] != 'O' && _fieldBOT[i, j] != 'X')
                    {
                        _fieldBOT[i, j] = board[i, j];
                    }
                }
            }
            return true;
        }
    }
}
