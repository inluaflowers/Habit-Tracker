using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

namespace UserInterface.States;
public abstract class State
{
    public InterfaceContext? Context;
    private readonly Menu _menu = new Menu();
    public Dictionary<string, Action> _stateActions = new Dictionary<string, Action>();
    public void SetContext(InterfaceContext context)
    {
        Context = context;
    }
    public  void AddMenuStateAction(MenuEnum itemType, string itemKey, State state, string? assignedName = null, float? assignedFloat = null)
    {
        _menu.AddItem(itemType, itemKey, assignedName, assignedFloat);
        _stateActions.Add(itemKey, () => Context.TransitionTo(state));
    }

    public List<MenuItem> AllMenuItems()
    {
        return _menu.AllMenuItems();
    }
    public abstract void Display();
    public abstract void BuildMenuActions();
}

