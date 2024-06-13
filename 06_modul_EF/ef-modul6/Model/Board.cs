// Board.cs
namespace Model
{
    public class Board
    {
        public Board()
        {
        }
        public int BoardId { get; set; }
        public List<Todo> Todos { get; set; }
    }
}