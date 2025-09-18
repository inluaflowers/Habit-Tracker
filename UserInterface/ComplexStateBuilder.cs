using System.Dynamic;

namespace UserInterface;

internal class ComplexStateBuilder
{
    private readonly string _stateTitle;

}
public class ComplexMenuItem(
    string itemKey,
    string? assignedName = null,
    float? assignedFloat = null)
{
    private string ItemItemKey { get; set; } = itemKey;
    private string? AssignedName { get; set; } = assignedName;
    private float? AssignedFloat { get; set; } = assignedFloat;

    public override string ToString()
    {
        var namedItemString = AssignedName != null ? $": {AssignedName}" : "";
        var floatValue = AssignedFloat != null ? AssignedFloat.ToString() : "";
        return $"{ItemItemKey}{namedItemString}{floatValue}";
    }
}