using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.States;

public class ViewHabitTrackerState : State
{
    private readonly string _title = "Select a Habit Tracker to View";
    private readonly List<string> _navigationChoices = ["Coding", "CPAP Usage"];
    public override void Display()
    {
        var choice = InterfaceType.SelectionPrompt(_title, _navigationChoices);
    }
}

