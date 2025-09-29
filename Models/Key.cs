namespace TheKeySystem.Models;

public class Key
{
    public long Id { get; set; }
    public int Number { get; set; }

    public Key(long id, int number)
    {
        Id = id;
        Number = number;
    }
}