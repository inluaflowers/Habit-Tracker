using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UserInterface.States;

public class MainMenuState : State
{
    private const string StateTitle = "Main Menu";

    public override void BuildMenuActions()
    {

        AddMenuStateAction(MenuEnum.Navigation, "View Habit Tracker", new ViewHabitTrackerState());
        AddMenuStateAction(MenuEnum.Navigation, "Create New Habit", new AddHabitTrackerState());
        AddMenuStateAction(MenuEnum.Navigation, "Exit", new ExitState());
    }
    public override void Display()
    {
        var choice = InterfaceType.SelectionPrompt(StateTitle, AllMenuItems());
        _stateActions[choice.ItemKey]();
    }
}

