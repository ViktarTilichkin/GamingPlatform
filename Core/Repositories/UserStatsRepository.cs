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
        protected string NameFile = "stats.txt";
        public void AddUserStats(UserStats userStats)
        {
            if (userStats == null) throw new ArgumentNullException(nameof(userStats));
            List<UserStats> users = GetAll(NameFile).ToList();
            users.Add(userStats);
            UpdateFile(users);
        }
        public List<UserStats> GetUserStats(int id)
        {
            List<UserStats> users = GetAll(NameFile).ToList();
            List<UserStats> stats = new List<UserStats>();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    stats.Add(users[i]);
                }
            }
            return stats;
        }
        public List<UserStats> GetAllStats()
        {
            List<UserStats> users = GetAll(NameFile).ToList();
            return users;
        }
    }
}
