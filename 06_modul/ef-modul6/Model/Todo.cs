// Todo.cs

namespace Model
{
    public class Todo
    {
        public int TodoId { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public User? User { get; set; }
        public Board? Board { get; set; }
    }
}