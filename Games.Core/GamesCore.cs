using System.Reflection.Metadata;
using Core.Models;
using Core.Repositories;

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
        public User user { get; private set; } 
        public UserStatsRepository Stats = new UserStatsRepository();



    }
}