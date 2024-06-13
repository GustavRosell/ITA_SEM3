public class User : IComparable<User> // Tilføjer IComparable<User> for at angive at User kan sammenlignes
{
    public string Name { get; set; }
    public int Id { get; set; }

    public User (string name, int id) {
        this.Name = name;
        this.Id = id;
    }

    // Metode til at sammenligne to User-objekter 
    // Bliver ikke brugt, dog gør koden mere modulær og genadvendelig
    public int CompareTo(User other)
    {
        // Tjekker om objektet vi vil sammenligne med (other) er null
        // retunere 1, vores objeket er altså større end det vi sammenligner med
        if (other == null) return 1;

        // Sammenligner to objektet baseret på Id
        // Metoden retunere 0 hvis de to objekteter vi sammenligner er ens
        // Metoden retunere en positiv værdi, hvis this er større end (other)
        // Metoden retunere en negativ værdi, hvis (other) er større end this
        return this.Id.CompareTo(other.Id);
    }
}