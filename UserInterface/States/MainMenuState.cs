using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UserInterface.States;

public class MainMenuState : State
{
    private readonly string _title = "Main Menu";
    private readonly List<string> _navigationChoices = ["View Habit Tracker", "Add Habit Tracker", "Exit"];
    public override void Display()
    {
        NullContextCheck();
        var choice = InterfaceType.SelectionPrompt(_title, _navigationChoices);
        switch (choice)
        {
            case "View Habit Tracker":
                Context.TransitionTo(new ViewHabitTrackerState());
                break;
            case "Add Habit Tracker":
                Context.Cache = new Cache();
                Context.Cache.CacheDictionary = Context.Cache.NewHabitDictionary;
                Context.TransitionTo(new AddHabitTrackerState());
                break;
            case "Exit":
                Console.Clear();
                break;
        }
    }
}

