namespace UserInterface;
public class InterfaceContext
{
    public State State = null;
    public Cache? Cache = null;

    public InterfaceContext(State state)
    {
        TransitionTo(state);
    }
    public void TransitionTo(State state)
    {
        State = state;
        State.SetContext(this);
        Display();
    }

    public void Display()
    {
        State.Display();
    }
}
public abstract class State
{
    public InterfaceContext? Context;

    public void SetContext(InterfaceContext context)
    {
        Context = context;
    }

    public void NullContextCheck()
    {
        if (Context is null)
        {
            throw new Exception($"Context is Not Set for {this}");
        }
    }

    public abstract void Display();

}
public class MainMenu : State
{
    private readonly string _title = "Main Menu";
    private readonly string[] _menuChoices = ["View Habit Tracker", "Add Habit Tracker"];
    public override void Display()
    {
        NullContextCheck();
        var choice = InterfaceType.SelectionPrompt(_title, _menuChoices);
        switch (choice)
        {
            case "View Habit Tracker":
                Context.TransitionTo(new ViewHabitTracker());
                break;
            case "Add Habit Tracker":
                Context.Cache = new AddHabitCache();
                Context.TransitionTo(new AddHabitTracker());
                break;
        }
    }
}
public class ViewHabitTracker : State
{
    private readonly string _title = "Select a Habit Tracker to View";
    private readonly string[] _menuChoices = ["Coding", "CPAP Usage"];
    public override void Display()
    {
        var choice = InterfaceType.SelectionPrompt(_title, _menuChoices);
    }
}
public class AddHabitTracker : State
{
    private readonly string _title = "Create Your Habit Tracker";
    private readonly string[] _menuChoices = ["Name" , "Unit of Measurement"];
    public override void Display()
    {
        NullContextCheck();
        var choice = InterfaceType.SelectionPrompt(_title, _menuChoices, Context.Cache.CacheDictionary);
        switch (choice)
        {
            case "Name":
                Context.TransitionTo(new EnterNameState());
                break;
            case "Unit of Measurement":
                Context.TransitionTo(new EnterUnitOfMeasurementNameState());
                break;
        }
    }
}
public class EnterNameState : State
{
    private readonly string _title = "Choose a Name for your Habit";
    public override void Display()
    {
        var choice = InterfaceType.AskPrompt<string>(_title);
        NullContextCheck();
        Context.Cache.CacheDictionary["Habit Name"] = choice;
        Context.TransitionTo(new AddHabitTracker());
    }
}
public class EnterUnitOfMeasurementNameState : State
{
    private readonly string _title = "Choose a Unit of Measurement for your Habit";
    public override void Display()
    {
        var choice = InterfaceType.AskPrompt<string>(_title);
        NullContextCheck();
        Context.Cache.CacheDictionary["Unit of Measurement"] = choice;
        Context.TransitionTo(new AddHabitTracker());
    }
}