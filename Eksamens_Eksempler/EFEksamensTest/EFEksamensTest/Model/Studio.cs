namespace Model
{
    public class Studio
    {
        public Studio()
        {
        }

        public Studio(string name)
        {
            this.Name = name;

        }

        public int StudioId { get; set; }
        public string Name { get; set; }

        public List<Film> Films { get; set; } = new List<Film>();
    }
}