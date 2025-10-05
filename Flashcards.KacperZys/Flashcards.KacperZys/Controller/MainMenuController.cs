using Flashcards.KacperZys.Model;
using Spectre.Console;

namespace Flashcards.KacperZys.Controller;
internal class MainMenuController
{
    public void ManageStacks()
    {

        //TODO: Display Stacks from database ans save to list
        List<StackDTO> stacks = new();
        StackDTO input = AnsiConsole.Ask<StackDTO>("Enter name of the stack you want to manage. Input exit to leave.");

    }

    private void CreateStack()
    {


    }

    internal void ManageFlashcards()
    {
        throw new NotImplementedException();
    }

    internal void Study()
    {
        throw new NotImplementedException();
    }

    internal void ViewStudySessionData()
    {
        throw new NotImplementedException();
    }
}
