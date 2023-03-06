using System.Reflection.Metadata;
using System.Xml.Linq;
using GameBak_Dice;
using Games.Shared;
using GameXO;

namespace Games.Core
{
    public class GamesCore
    {

        private XO xo = new XO();
        private BakDice bakdice = new BakDice();
        public int IdUser { get; set; }

        public GamesCore(int idUser)
        {
            IdUser = idUser;
        }

        public void MenuGames(int id, string userName, out string gameResult)
        {
            IdUser = id;
            gameResult = null;
            Console.WriteLine($"Hi! {userName}");
            Console.WriteLine($"What game do you want to play?");
            Console.WriteLine($"{(int)EnumGame.XO} XO Game");
            Console.WriteLine($"{(int)EnumGame.BakDice} Bak-Dice Game");
            Console.WriteLine($"0 Out");
            if (int.TryParse(Console.ReadLine(), out var codeMenu))
            {
                if (codeMenu == (int)EnumGame.XO)
                {
                    xo.StartGame(5, userName, out gameResult);
                }
                else if (codeMenu == (int)EnumGame.BakDice)
                {
                    bakdice.StartGame(5, userName, out gameResult);
                }
            }
        }
    }
}