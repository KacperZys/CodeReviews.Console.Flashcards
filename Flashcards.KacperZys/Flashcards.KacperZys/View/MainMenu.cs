using Flashcards.KacperZys.Controller;
using Spectre.Console;

namespace Flashcards.KacperZys.View;
internal static class MainMenu
{
    public static void Display()
    {
        MainMenuController mainMenuController = new();

        var options = Enum.GetValues<Option>();
        List<string> optionsString = new();
        foreach (Option option in options)
        {
            optionsString.Add(option.ToString().Replace('_', ' '));
        }

        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Menu options.")
            .AddChoices(optionsString));

        switch (Enum.Parse<Option>(selection.Replace(' ', '_')))
        {
            case Option.Manage_Stacks:
                mainMenuController.ManageStacks();
                break;
            case Option.Manage_Flashcards:
                mainMenuController.ManageFlashcards();
                break;
            case Option.Study:
                mainMenuController.Study();
                break;
            case Option.View_Study_Session_Data:
                mainMenuController.ViewStudySessionData();
                break;
            case Option.Exit:
                return;
            default:
                throw new Exception("Something went wrong. Please try again.");
        }
    }
}

public enum Option
{
    Manage_Stacks,
    Manage_Flashcards,
    Study,
    View_Study_Session_Data,
    Exit
}
