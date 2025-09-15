namespace UserInterface;

public interface IMediator
{
    public void Notify(object? sender, object? payload);
}

public class ConcreteMediator : IMediator
{
    private readonly Menu _mainMenu;
    private readonly Menu _addHabitMenu;
    public ConcreteMediator(Menu mainMenu, Menu addHabitMenu, Cache cache)
    {
        _mainMenu = mainMenu;
        _addHabitMenu = addHabitMenu;
        _mainMenu.SetMediator(this);
    }
    public void Notify(object? sender, object? payload)
    {
        switch (payload)
        {
            case MenuName.Main:
                _mainMenu.Display();
                break;
            case MenuName.AddHabit:
                _addHabitMenu.Display();
                break;
        }
    }
}

public enum MenuName
{
    Main,
    ViewHabit,
    LogHabit,
    AddHabit,
    EditHabit,
    EditUnitOfMeasurement,
    Exit
}