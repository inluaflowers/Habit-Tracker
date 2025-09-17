namespace UserInterface.States;

public class ConfirmManyState<T, TU>(string itemToConfirm, Cache Cache) : State
    where T : State, new()
    where TU : State, new()
{
    private readonly string _confirmationListAsString =
        HelperMethods.ZipperAsString(Cache.CacheDictionary.Keys.ToList(), Cache.CacheDictionary.Values.ToList());

    private string _title = $"Confirm {itemToConfirm} Selections: Y/N?\n";
    public override void Display()
    {
        _title += _confirmationListAsString + "\n";
        var choice = InterfaceType.AskPrompt<string>(_title);
        switch (choice.Trim().ToLower())
        {
            case "y":
                Console.WriteLine($"{itemToConfirm} has been completed\nPress any key to continue.");
                Console.ReadLine();
                Console.Clear();
                Context.TransitionTo(new T());
                break;
            case "n":
                Context.TransitionTo(new TU());
                break;
        }

    }
}
public class ConfirmOneState<T>(string itemToConfirm, Action action) : State
    where T : State, new()
{
    private readonly string _title = $"Confirm {itemToConfirm} Selections: Y/N?\n";
    public override void Display()
    {
        var choice = InterfaceType.AskPrompt<string>(_title);
        switch (choice.Trim().ToLower())
        {
            case "y":
                Console.Clear();
                action();
                break;
            case "n":
                break;
        }
        Context.TransitionTo(new T());
    }
}

public class EnterNameState<T>(string itemToName) : State
    where T : State, new()
{
    private readonly string _title = $"Choose a {itemToName}";
    public override void Display()
    {
        var choice = InterfaceType.AskPrompt<string>(_title);
        Context.Cache.CacheDictionary[itemToName] = choice;
        Context.TransitionTo(new T());
    }
}

public class EnterNameAndFactorState<T>(string itemToName, string baseUnitOfMeasurement) : State
    where T : State, new()
{
    private readonly string _nameTitle = $"Name your {itemToName}";
    private readonly string _factorOfBase = $"How many {baseUnitOfMeasurement}s are in a";
    public override void Display()
    {
        var unitOfMeasurementName = InterfaceType.AskPrompt<string>(_nameTitle);
        Context.Cache.CacheDictionary[itemToName] = unitOfMeasurementName;

        var factor = InterfaceType.AskPrompt<float>($"{_factorOfBase} {unitOfMeasurementName}?");
        Context.Cache.ConversionDictionary[unitOfMeasurementName] = factor;

        Context.TransitionTo(new T());
    }
}