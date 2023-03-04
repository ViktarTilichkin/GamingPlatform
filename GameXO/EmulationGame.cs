using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXO
{
    public class EmulationGame
    {
        public char[] fieldROW1 { get; set; } = new char[3]
        { '1', '2', '3' }
                   ;
        public char[] fieldROW2 { get; set; } = new char[3]
        { '1', '2', '3' }
                   ;
        public char[] fieldROW3 { get; set; } = new char[3]
        { '1', '2', '3' }
                   ;
        public bool isXMove { get; set; } = true;
        public bool SideToPlayerX { get; set; } = true;
        public char SideToPlayer { get; set; } = 'X';
        public bool PlayerVsBot { get; set; } = false;
        public int PlaeyrId { get; set; }
        public override string ToString()
        {
            return $"{fieldROW1} + {fieldROW2} + {fieldROW3} + {isXMove} + {SideToPlayerX} + {SideToPlayer}";
        }
    }
}
