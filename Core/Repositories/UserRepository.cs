using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using System.Text.Json;

namespace Core.Repositories
{
    public class UserRepository
    {

        public List<User> GetAll()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            List<User> users = new List<User>();
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            try
            {
                using StreamReader sr1 = new StreamReader($"{path}users.txt");
                string line = sr1.ReadLine();
                while (line != null)
                {
                    User user = JsonSerializer.Deserialize<User>(line, serializeoptions);
                    users.Add(user);
                    line = sr1.ReadLine();
                }
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
    }
}
