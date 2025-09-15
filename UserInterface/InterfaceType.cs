using Spectre.Console;

namespace UserInterface;
public class InterfaceType
{
    public static string SelectionPrompt(string title, string[] menuChoices)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .AddChoices(menuChoices)
        );
    }
    public static string SelectionPrompt(string title, string[] menuChoices, Dictionary<string, object> cacheDictionary)
    {
        var cacheValuesAsList = cacheDictionary.Values.ToList();
        var cacheValuesAsStrings = cacheValuesAsList.ConvertAll(i => i.ToString());
        var zippedChoices = menuChoices.Zip(cacheValuesAsStrings, (first, second) => first + ": " + second).ToList();
        string[] joinedChoices;

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .AddChoices(zippedChoices)
        );
        return menuChoices[zippedChoices.IndexOf(choice)];
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
