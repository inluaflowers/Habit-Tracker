using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface;
public class UserInterface
{
    public Menu InterfaceState;

    private readonly Dictionary<MenuName, Menu> _interfaceDictionary = new()
    {
        {MenuName.Main, new MainMenu()}
    };

    public UserInterface()
    {
        InterfaceState = _interfaceDictionary[MenuName.Main];
    }

    public void TransitionState(MenuName menuName)
    {

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

