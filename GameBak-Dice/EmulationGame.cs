using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBak_Dice
{
    public class EmulationGame
    {
        public List<Player> playerList = new List<Player>();
        public int PlayerId { get; set; }
        public int ValuesFrend { get; set; }
        public int ValuesBot { get; set; }
        public int Bak = 4;
        public string PlayerName { get; set; }
        public bool Dice = false;
        public override string ToString()
        {
            return $"{PlayerId} + {ValuesFrend} + {ValuesBot} + {Bak} + {PlayerName} + {Dice}";
        }
    }
}
