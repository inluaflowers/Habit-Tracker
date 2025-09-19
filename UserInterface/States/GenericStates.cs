using System.Runtime.CompilerServices;

namespace UserInterface.States;

/*public class ConfirmManyState<T, TU>(string itemToConfirm, Cache Cache) : State
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

    public override void BuildMenuStates()
    {
        throw new NotImplementedException();
    }
} */


public class InputState<TParentState, TInput>(string itemKey) : BaseState
    where TParentState : BaseState, new()
{
    private readonly string _title = $"Choose a {itemKey}";
    public override void Display()
    {
        var choice = InterfaceType.AskPrompt<TInput>(_title);
        switch (choice)
        {
            case string s:
                Context.Cache.MenuItemCache[itemKey].AssignedName = s;
                break;
            case float f:
                Context.Cache.MenuItemCache[itemKey].AssignedFloat = f;
                break;
            default:
                throw new Exception("Choice is Null");
        }
        Context.TransitionTo(new TParentState());
    }

    public override void BuildMenuStates()
    {
    }

}
public class EnterFactorState<TParentState>(string itemKey) : BaseState
    where TParentState : BaseState, new()
{
    private readonly string _title = $"Choose a {itemKey}";

    public override void Display()
    {
        float? choice = InterfaceType.AskPrompt<float>(_title);
        Context.Cache.MenuItemCache[itemKey].AssignedFloat = choice;
        Context.TransitionTo(new TParentState());
    }

    public override void BuildMenuStates()
    {
    }

}
public class AdditionalUnitOfMeasurement<TParentState> : BaseState
where TParentState : BaseState, new()
{
    public override void Display()
    {
        Context.Cache.MeasurementCount++;
        var itemKey = $"Unit of Measurement {Context.Cache.MeasurementCount}";
        Context.Cache.MenuItemCache.Add(itemKey, new MenuItem(MenuEnum.Value, itemKey, "None"));
        Context.Cache.ActionCache.Add(itemKey, () => Context.TransitionTo(new InputState<TParentState>(itemKey)));
        Context.TransitionTo(new TParentState());
    }

    public override void BuildMenuStates()
    {

    }
}