using Spectre.Console;

namespace UserInterface;
public class InterfaceType
{
    public static string SelectionPrompt(string title, List<string> navigationChoices)
    {
        var returnChoices = navigationChoices.Concat(navigationChoices).ToList();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .AddChoices(navigationChoices)
        );
        return choice;
    }
    public static string SelectionPrompt(string title, List<string> itemChoices, List<string> navigationChoices)
    {

        var displayChoices = HelperMethods.ConcatFirstListWithColon(itemChoices, navigationChoices);
        var returnChoices = itemChoices.Concat(navigationChoices).ToList();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .AddChoices(displayChoices)
        );
        return returnChoices[displayChoices.IndexOf(choice)];
    }
    public static string SelectionPrompt(string title, List<string> itemChoices, List<string> navigationChoices, Cache cache)
    {
        var displayChoices = HelperMethods.ConcatFirstListWithColon(itemChoices, navigationChoices);
        var returnChoices = itemChoices.Concat(navigationChoices).ToList();
        var zippedChoices = HelperMethods.Zipper(displayChoices, cache.CacheDictionary.Values.ToList(), fill: true);

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .AddChoices(zippedChoices)
        );
        return returnChoices[zippedChoices.IndexOf(choice)];
    }
    public static T AskPrompt<T>(string title)
    {
        while (true)
        {
            var input = AnsiConsole.Ask<T>(title);
            if (input is not null)
            {
                return input;
            }
        }
    }
}
