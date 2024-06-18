namespace Model
{
    public class Actor
    {
        public Actor()
        {
        }

        public Actor(string name, string køn)
        {
            this.Name = name;
            this.Køn = køn;
        }

        public int ActorId { get; set; }
        public string Name { get; set; }
        public string Køn { get; set; }
    }
}