namespace Model
{
    public class Board
    {
        public int BoardId { get; set; }
        public string? Name { get; set; }
        public List<Todo> Todos { get; set; } = new List<Todo>();
    }
}