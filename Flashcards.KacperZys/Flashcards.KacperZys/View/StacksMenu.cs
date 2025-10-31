using Flashcards.KacperZys.Controller;

namespace Flashcards.KacperZys.View;
internal class StacksMenu
{
    internal void Display()
    {
        StacksController stacksController = new();
        Options selection = SharedMenuOptionsController.SetMenuOptions<Options>();

        switch (selection)
        {
            case Options.Display_Stacks:
                stacksController.DisplayStacks();
                break;
            case Options.Create_Stack:
                stacksController.Create();
                break;
            case Options.Modify_Stack:
                stacksController.Modify();
                break;
            case Options.Delete_Stack:
                stacksController.Delete();
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
