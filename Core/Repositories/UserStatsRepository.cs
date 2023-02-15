using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Repositories
{
    public class UserStatsRepository : BaseRepository<UserStats>
    {
        protected override string path { get; } = AppDomain.CurrentDomain.BaseDirectory + "stats.txt";
        // унаследовали метод гет аалл
        // апдейт фаил 
        // метод поулчения статистики по игроку
        // запись статистики
        public void AddUserStats(UserStats userStats)
        {
            if (userStats == null) throw new ArgumentNullException(nameof(userStats));
            List<UserStats> users = GetAll();
            users.Add(userStats);
            UpdateFile(users);
        }
        public List<UserStats> GetUserStats(User user)
        {
            List<UserStats> users = GetAll();
            List<UserStats> stats = new List<UserStats>();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].user.Id == user.Id)
                {
                    stats.Add(users[i]);
                }
            }
            return stats;
        }
    }
}
