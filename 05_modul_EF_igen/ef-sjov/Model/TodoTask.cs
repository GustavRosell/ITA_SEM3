namespace Model
{
    public class TodoTask
    {
        public TodoTask(string text, bool done, string category, User user) // Ny parameter category(opg3) // Ny parameter user(opg4)
        {
            this.Text = text;
            this.Done = done;
            this.Category = category;
            this.User = user;
        }

        // Constructor UDEN User:
        public TodoTask(string text, bool done, string category)
        {
            this.Text = text;
            this.Done = done;
            this.Category = category;
        }

        public long TodoTaskId { get; set; }
        public string? Text { get; set; }
        public bool Done { get; set; }
        public string? Category { get; set; }
        public User User { get; set; }  // Ny property tilføjet - Opgave 4
    }
}
