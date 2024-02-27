
namespace Model
{
    public class Todo
    {
        public Todo(string text, string category, User user) {
            this.Text = text;
            this.User = user;
            this.Category = category;
        }

         public Todo(string text, string category) {
            this.Text = text;
            this.Category = category;
        }  

        public long TodoId { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? Category {get; set; }
        public User? User {get; set;}
    }
}