using System.Reflection.Metadata;
using System.Xml.Linq;
using UserInterface;
namespace UserInterface.States;

/*public class AddHabitTrackerState : State
{
    private const string Title = "Create Your Habit Tracker";
    private const string HabitName = "Habit Name";
    private const string UnitOfMeasurement = "Unit of Measurement";
    private const string AddUnitOfMeasurementStr = "Add Unit of Measurement";
    private const string ConfirmNewHabit = "New Habit";
    private const string ConfirmAdditionalUnitOfMeasurement = "Additional Unit Of Measurement";
    private const string Confirm = "Confirm";
    private const string Cancel = "Cancel";

    private readonly List<string> _itemChoices = [HabitName];
    private readonly List<string> _navigationChoices = [AddUnitOfMeasurementStr, Confirm, Cancel];
    private readonly Dictionary<string, Action> _stateDictionary = new Dictionary<string, Action>();

    public override void Display()
    {
        BuildActionDictionary();
        var choice = InterfaceType.SelectionPrompt(Title, _itemChoices, _navigationChoices, Context.Cache);
        _stateDictionary[choice]();
    }
    public void BuildActionDictionary()
    {
        _stateDictionary[HabitName] = () => Context.TransitionTo(new EnterNameState<AddHabitTrackerState>(HabitName));

        for (var i = 1; i < Context.Cache.NumberOfMeasurements; i++)
        {
            var name = $"{UnitOfMeasurement} {i}";
            _itemChoices.Add(name);
            if (i == 1)
                _stateDictionary[name] = () => Context.TransitionTo(new EnterNameState<AddHabitTrackerState>(name));
            if (i > 1)
                break;
        }

        _stateDictionary[AddUnitOfMeasurementStr] = 
            () => Context.TransitionTo(new ConfirmOneState<AddHabitTrackerState>(ConfirmAdditionalUnitOfMeasurement, () => Context.Cache.NumberOfMeasurements++));
        _stateDictionary[Confirm] = 
            () => Context.TransitionTo(new ConfirmManyState<MainMenuState, AddHabitTrackerState>(ConfirmNewHabit, Context.Cache));
        _stateDictionary[Cancel] = () => Context.TransitionTo(new MainMenuState());
    }
}*/

public sealed class AddHabitTrackerState : State
{

    private const string StateTitle = "Build A Habit Tracker";
    public override void BuildMenuActions()
    {
        AddMenuStateAction(MenuEnum.Value, "Habit Name", new EnterNameState<AddHabitTrackerState>("Habit Name"));
        AddMenuStateAction(MenuEnum.Navigation, "Confirm", new ConfirmManyState<MainMenuState, AddHabitTrackerState>("New Habit", Context.Cache));
        AddMenuStateAction(MenuEnum.Navigation, "Cancel", new MainMenuState());

        for (var i = 1; i < Context.Cache.NumberOfMeasurements; i++)
        {
            var name = "";

            switch (i)
            {
                case 1:
                    name = "Base Unit of Measurement";
                    AddMenuStateAction(MenuEnum.Value, name, new EnterNameState<AddHabitTrackerState>(name));
                    break;
                case > 1:
                    name = $"Unit of Measurement {i}";
                    AddMenuStateAction(MenuEnum.Value, name,
                        new EnterNameAndFactorState<AddHabitTrackerState>(name, "Base Unit Of Measurement"));
                    break;

            }
        }
    }
    public override void Display()
    {
        var choice = InterfaceType.SelectionPrompt(StateTitle, AllMenuItems());
        _stateActions[choice.ItemKey]();
    }

}
