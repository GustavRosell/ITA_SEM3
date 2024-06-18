namespace Model
{
    public class Film
    {
        public Film()
        {
        }

        public Film(string Beskrivelse)
        {
            this.Beskrivelse = Beskrivelse;
        }

        public int FilmId { get; set; }
        public string Beskrivelse { get; set; }

        public List<Actor> Actors { get; set; } = new List<Actor>();
    }
}