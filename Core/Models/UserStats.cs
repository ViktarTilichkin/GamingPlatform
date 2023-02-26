using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserStats
    {
        public int Id { get; set; }
        public string GameResult { get; set; }
        public string GameName { get; set; }
        public DateTime time = DateTime.Now;

        public UserStats(int id, string gameResult)
        {
            Id = id;
            GameResult = gameResult;
        }

        public override string ToString()
        {
            return $"{GameName} result: {GameResult} {time}";
        }
    }
}
