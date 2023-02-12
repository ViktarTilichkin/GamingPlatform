using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Repositories
{
    internal class UserStatsRepository : BaseRepository<User>
    {
        protected override string path { get;  } = AppDomain.CurrentDomain.BaseDirectory + "stats.txt";
        public int Id { get; set; }
        public string Name { get; set; }

        //public Liset<UserStats> GetAll()
        //{
        //    try
        //    {

        //    }
        //    catch 
        //    { 
        //    }

        //}
    }
}
