using System.Text.Json.Serialization;

namespace Core.Models
{
    public class User : ICloneable
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
        [JsonConstructor]
        public User(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }

        public override string ToString()
        {
            return $"{Id}  {Name} {Password}";
        }

        public object Clone() => new User(Id, Name, Password);
    }
}