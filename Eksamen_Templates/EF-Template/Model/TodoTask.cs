// TodoTask.cs
namespace Model
{
    public class TodoTask
    {
        public TodoTask(string text, bool done) {
            this.Text = text;
            this.Done = done;
        }
        public long TodoTaskId { get; set; }
        public string? Text { get; set; }
        public bool Done { get; set; }
    }
}