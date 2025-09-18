using System.Dynamic;

namespace UserInterface;

public class Menu
{
    private readonly List<MenuItem> _valueItems = [];
    private readonly List<MenuItem> _navigationItem = [];
    public void AddItem(MenuEnum itemType, string itemKey, string? assignedName = null, float? assignedFloat = null)
    {
        switch (itemType)
        {
            case MenuEnum.Value:
                _valueItems.Add(new MenuItem(itemKey, assignedName, assignedFloat));
                break;
            case MenuEnum.Navigation:
                _navigationItem.Add(new MenuItem(itemKey, assignedName, assignedFloat));
                break;
            default:
                throw new Exception("Menu Enum does not exist");
        }
    }

    public List<MenuItem> AllMenuItems()
    {
        return _valueItems.Concat(_navigationItem).ToList();
    }

}
public class MenuItem(
    string itemKey,
    string? assignedName = null,
    float? assignedFloat = null)
{
    public string ItemKey { get; set; } = itemKey;
    private string? AssignedName { get; set; } = assignedName;
    private float? AssignedFloat { get; set; } = assignedFloat;

    public override string ToString()
    {
        var namedItemString = AssignedName != null ? $": {AssignedName}" : "";
        var floatValue = AssignedFloat != null ? AssignedFloat.ToString() : "";
        return $"{ItemKey}{namedItemString}{floatValue}";
    }
}

public enum MenuEnum
{
    Value,
    Navigation
}