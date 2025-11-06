using Spectre.Console;

namespace Flashcards.KacperZys.Controller;
internal static class SharedMenuOptionsController
{
    public static T SetMenuOptions<T>() where T : struct, Enum
    {
        var options = Enum.GetValues(typeof(T));
        List<string> optionsString = new();
        foreach (T option in options)
        {
            var optionString = option.ToString()?.Replace('_', ' ') ?? string.Empty;
            optionsString.Add(optionString);
        }

        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Menu options")
            .AddChoices(optionsString));

        return Enum.Parse<T>(selection.Replace(' ', '_'));
    }
}
