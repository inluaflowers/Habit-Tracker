namespace UserInterface;
public class Selection
{
    private string Name { get; set;}
    public Selection(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}

