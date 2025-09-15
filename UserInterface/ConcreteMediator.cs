namespace UserInterface;

public interface IMediator
{
    public void Notify(object? sender, object? payload);
}

public class ConcreteMediator : IMediator
{
    private UserInterface _userInterface;
    private Cache _cache;
    public ConcreteMediator(UserInterface userInterface, Cache cache)
    {
        _userInterface = userInterface;
        _userInterface.SetMediator(this);

        _cache = cache;
        _cache.SetMediator(this);
    }
    public void Notify(object? sender, object? payload)
    {

    }
}

