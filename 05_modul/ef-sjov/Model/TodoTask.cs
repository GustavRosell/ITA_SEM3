using Microsoft.Net.Http.Headers;

namespace Model
{
    public class TodoTask
    {
        public TodoTask(string text, string category, bool done, User user) {
            this.Text = text;
            this.Category = category;
            this.Done = done;
            this.User = user;
        }

         public TodoTask(string text, string category, bool done) {
            this.Text = text;
            this.Category = category;
            this.Done = done;
        }  

        public long TodoTaskId { get; set; }
        public string? Text { get; set; }
        public string? Category { get; set; }
        public bool Done { get; set; }
        public long? UserId {get ; set;}
        public User? User {get; set;}

    }
}