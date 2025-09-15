using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface;
public class UserInterface
{
    public Menu InterfaceState;
    private IMediator? _mediator;

    private readonly Dictionary<MenuName, Menu> _interfaceDictionary = new()
    {
        {MenuName.Main, new MainMenu()},
        {MenuName.AddHabit, new AddHabitMenu()}
    };

    public UserInterface(IMediator? mediator = null)
    {
        _mediator = mediator;
        InterfaceState = _interfaceDictionary[MenuName.Main];
    }

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
        foreach (var value in _interfaceDictionary.Values.ToList())
        {
            value.SetMediator(_mediator);
        }
    }

    public void TransitionState(MenuName menuName)
    {
        InterfaceState = _interfaceDictionary[menuName];
    }

    public void Notify(object? sender, object? payload)
    {
        if (InterfaceState.Mediator is null)
        {
            throw new Exception($"{InterfaceState.ToString()} Mediator Not Set");
        }
        InterfaceState.Mediator.Notify(sender, payload);
    }

    public enum MenuName
    {
        Main,
        ViewHabit,
        LogHabit,
        AddHabit,
        EditHabit,
        EditUnitOfMeasurement,
        Exit
    }
}

