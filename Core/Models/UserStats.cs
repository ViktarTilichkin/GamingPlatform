using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserStats
    {
        public User user { get; set; }
        public string GameResult { get; set; }
        public string GameName { get; set; }
        public DateTime time = DateTime.Now;

        public UserStats(User user, string gameResult)
        {
            this.user = user;
            GameResult = gameResult;
        }

        public override string ToString()
        {
            return $"User {user.Name} {GameName} result: {GameResult} {time}";
        }
    }
}
