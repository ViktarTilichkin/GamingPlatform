using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;

namespace Core.Services
{
    public class UserStatService
    {
        private readonly UserStatsRepository _userStatsRepository = new UserStatsRepository();

        public List<UserStats> GetAllStats()
        {
            return _userStatsRepository.GetAllStats();
        }
        public List<UserStats> GetStatsUser(int id)
        {
            return _userStatsRepository.GetUserStats(id);
        }
        public void AddUserStats(UserStats userStats)
        {
            _userStatsRepository.AddUserStats(userStats);
        }
    }
}
