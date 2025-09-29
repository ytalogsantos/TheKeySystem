namespace TheKeySystem.Models;

public class Collaborator
{
    public long Id { get; set; }
    public string Name { get; set; }

    public Collaborator(string name)
    {
        Name = name;
    }
}