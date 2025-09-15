using Spectre.Console;
namespace UserInterface;

internal class Widgets
{
    internal static string SelectionPrompt(string title, string[] menuChoices)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .AddChoices(menuChoices)

        );
    }

    internal static T AskPrompt<T>(string title)
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

