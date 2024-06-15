namespace Model
{
public class Todo
    {
        public int TodoId { get; set; }
        public string? Title { get; set; }
        public User? User { get; set; }
        public Board? Board { get; set; }
    }
}