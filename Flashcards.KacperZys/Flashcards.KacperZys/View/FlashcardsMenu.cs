using Flashcards.KacperZys.Controller;

namespace Flashcards.KacperZys.View;
internal class FlashcardsMenu
{
    internal void Display()
    {
        Options selection = SharedMenuOptionsController.SetMenuOptions<Options>();

        switch (selection)
        {
            case Options.Display_Flashcards:

                break;
            case Options.Create_Flashcard:

                break;
            case Options.Modify_Flashcard:

                break;
            case Options.Delete_Flashcard:

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
        Exit
    }
}


