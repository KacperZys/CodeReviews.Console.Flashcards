using Flashcards.KacperZys.Controller;
using Spectre.Console;

namespace Flashcards.KacperZys.View;
internal static class MainMenu
{
    public static void Display()
    {
        MainMenuController mainMenuController = new();

        var options = Enum.GetValues<Options>();
        List<string> optionsString = new();
        foreach (Options option in options)
        {
            optionsString.Add(option.ToString().Replace('_', ' '));
        }

        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Menu options.")
            .AddChoices(optionsString));

        switch (Enum.Parse<Options>(selection.Replace(' ', '_')))
        {
            case Options.Manage_Stacks:
                StacksMenu stacksMenu = new();
                stacksMenu.Display();
                break;
            case Options.Manage_Flashcards:
                FlashcardsMenu flashcardsMenu = new();
                flashcardsMenu.Display();
                break;
            case Options.Study:
                StudyMenu studyMenu = new();
                studyMenu.Display();
                break;
            case Options.View_Study_Session_Data:
                mainMenuController.ViewStudySessionData();
                break;
            case Options.Exit:
                return;
            default:
                throw new Exception("Something went wrong. Please try again.");
        }
    }

    private enum Options
    {
        Manage_Stacks,
        Manage_Flashcards,
        Study,
        View_Study_Session_Data,
        Exit
    }
}