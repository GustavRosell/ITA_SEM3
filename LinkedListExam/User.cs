public class User {
    public string Name { get; set; }
    public int Age { get; set; }

    public User (string name, int age) {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString ()
    {
        return Name;
    }
}