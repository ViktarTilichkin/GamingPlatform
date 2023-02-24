using System.Reflection.Metadata;
using System.Xml.Linq;
using Games.Shared;
using GameXO;

namespace Games.Core
{
    public class GamesCore
    {
        // отсюда будем вызывать

        // функцианал коре 

        // принимать поля id для ведения статистики игры 
        // подключаться к репозиторию статистики и писать туда статистику по текущей игре 
        // отдельный фаил для породолжения игры !
        // - просмотр статистики игрока
        // - статистика по всем играм ??

        // интрфейс игры
        // - старт +
        // - старт из сохранения если такое есть +
        // - количество игроков +
        //public string user { get; private set; } 
        //public string  Stats = new UserStatsRepository();

        //поулчить имя пользователя id
        //    поулчить игру 

        //    и вызываем игру
        private XO games = new XO();
        public int IdUser { get; set; }

        public GamesCore(int idUser)
        {
            IdUser = idUser;
        }

        public void MenuGames(string userName, out string gameResult)
        {
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