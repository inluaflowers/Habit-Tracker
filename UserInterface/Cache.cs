namespace UserInterface;
public class Cache(IMediator? mediator = null)
{
    private IMediator? _mediator = mediator;

    internal Dictionary<string, string> AddHabitDictionary = new()
    {
        {"HabitName", ""},
        {"Unit of Measurement", ""}
    };

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }
}

