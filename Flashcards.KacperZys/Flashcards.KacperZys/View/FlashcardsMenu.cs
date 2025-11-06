using Flashcards.KacperZys.Controller;
using Spectre.Console;

namespace Flashcards.KacperZys.View;
internal class FlashcardsMenu
{
    internal void Display()
    {
        FlashcardsController flashcardsController = new();
        var stack = FlashcardsController.GetCurrentStack();
        AnsiConsole.MarkupLine($"[yellow]Current stack: {stack.Name}[/]");
        Options selection = SharedMenuOptionsController.SetMenuOptions<Options>();

        switch (selection)
        {
            case Options.Change_Current_Stack:
                FlashcardsController.SetCurrentStack();
                break;
            case Options.Display_Flashcards:
                flashcardsController.Display();
                break;
            case Options.Create_Flashcard:
                flashcardsController.Create();
                break;
            case Options.Modify_Flashcard:
                flashcardsController.Modify();
                break;
            case Options.Delete_Flashcard:
                flashcardsController.Delete();
                break;
            case Options.Exit:
                return;
            default:
                throw new Exception("Something went wrong. Please try again.");
        }
    }

    private enum Options
    {
        Change_Current_Stack,
        Display_Flashcards,
        Create_Flashcard,
        Modify_Flashcard,
        Delete_Flashcard,
        Exit
    }
}


