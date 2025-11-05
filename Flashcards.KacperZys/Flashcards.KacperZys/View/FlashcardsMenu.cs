using Flashcards.KacperZys.Controller;

namespace Flashcards.KacperZys.View;
internal class FlashcardsMenu
{
    internal void Display()
    {
        Options selection = SharedMenuOptionsController.SetMenuOptions<Options>();
        FlashcardsController flashcardsController = new();

        switch (selection)
        {
            case Options.Current_Stack:
                FlashcardsController.GetCurrentStack();
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
        Display_Flashcards,
        Create_Flashcard,
        Modify_Flashcard,
        Delete_Flashcard,
        Current_Stack,
        Exit
    }
}


