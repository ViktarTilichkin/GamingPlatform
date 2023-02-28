using System.Reflection.Metadata;
using System.Xml.Linq;
using Games.Shared;
using GameXO;

namespace Games.Core
{
    public class GamesCore
    {
        
        private XO games = new XO();
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
            Console.WriteLine($"0 Out");
            if (int.TryParse(Console.ReadLine(), out var codeMenu) && codeMenu == (int)EnumGame.XO)
            {
                games.StartGame(userName, out gameResult);
            }
        }
    }
}