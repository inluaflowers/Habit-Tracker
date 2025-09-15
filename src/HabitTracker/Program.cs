using System.Runtime.CompilerServices;
using SQLHandler;
using UserInterface;

Cache cache = new();
MainMenu mainMenu = new();
AddHabitMenu  addHabitMenu = new();
ConcreteMediator mediator = new ConcreteMediator(TODO);
mediator.Notify(null, MenuName.Main);