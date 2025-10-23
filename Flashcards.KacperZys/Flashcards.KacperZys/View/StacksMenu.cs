using Flashcards.KacperZys.Controller;

namespace Flashcards.KacperZys.View;
internal class StacksMenu
{
    internal void Display()
    {
        Options selection = SharedMenuOptionsController.SetMenuOptions<Options>();

        switch (selection)
        {
            case Options.Display_Stacks:

                break;
            case Options.Create_Stack:

                break;
            case Options.Modify_Stack:

                break;
            case Options.Delete_Stack:

                break;
            case Options.Exit:
                return;
            default:
                throw new Exception("Something went wrong. Please try again.");
        }
    }

    private enum Options
    {
        Display_Stacks,
        Create_Stack,
        Modify_Stack,
        Delete_Stack,
        Exit
    }
}
