namespace Model
{
    public class User
    {
        public User(string name) {
            this.Name = name;
        }     
        public long UserId { get; set; } // Primær-nøgle
        public string? Name { get; set; }
    }
}