namespace Core
{
    public class User
    {
        public int Id { get; }
        public string Name { get; set; } = "Name";
        public string Email { get; set; }
        public string Password { get; set; }
        public User(int id)
        {
            Id = id;
        }
        public User(int id, string name, string email, string password) : this(id)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"{Id}  {Name}";
        }
    }
}