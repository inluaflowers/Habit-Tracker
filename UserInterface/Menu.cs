using Spectre.Console;

namespace UserInterface;

public abstract class Menu(IMediator? mediator = null)
{
    public IMediator? Mediator = mediator;


    public void SetMediator(IMediator mediator)
    {
        this.Mediator = mediator;
    }

    public abstract void Display();
}

public class MainMenu : Menu
{
    private const string Title = "Main Menu";
    private readonly string[] _menuChoices = ["View Habit Tracker", "Log to Habit Tracker", "Add Habit Tracker", "Edit Habit Tracker", "Edit Unit of Measurement", "Exit"];

    public override void Display()
    {
        if (Mediator is null)
        {
            throw new Exception($"{this.ToString()} Mediator Not Set");
        }
        var choice = Widgets.SelectionPrompt(Title, _menuChoices);
        switch (choice)
        {
            case "Add Habit Tracker":
            {
                Mediator.Notify(this, MenuName.AddHabit);
                break;
            }
                
        }
    }
}

public class AddHabitMenu : Menu
{
    private const string Title = "Main Menu";
    private readonly string[] _menuChoices = ["Habit Name", "Unit of Measurement"];
    public override void Display()
    {
        var choice = Widgets.SelectionPrompt(Title, _menuChoices);
    }
}