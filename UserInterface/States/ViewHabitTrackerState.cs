using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.States;

public class ViewHabitTrackerState : State
{
    private const string StateTitle = "Select a Habit Tracker";

    public override void BuildMenuActions()
    {

        AddMenuStateAction(MenuEnum.Navigation, "Main Menu", new MainMenuState());
    }
    public override void Display()
    {
        var choice = InterfaceType.SelectionPrompt(StateTitle, AllMenuItems());
        _stateActions[choice.ItemKey]();
    }
}

