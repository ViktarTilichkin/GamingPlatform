using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBak_Dice
{
    public class Player
    {
        public string Name { get; set; }
        public int Bak { get; set; } = 0;
        public bool PlayRandom { get; set; } = true;
        public bool Bot { get; set; } = false;

        public int LastDice = 0;

        public override string ToString()
        {
            if (Bak >= 15)
            {
                return $"Name: {Name} Bak: {Bak}   You WIN";
            }
            return $"Name: {Name} Bak: {Bak}  ";
        }


    }
}
