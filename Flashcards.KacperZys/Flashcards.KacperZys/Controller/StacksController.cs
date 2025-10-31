using Flashcards.KacperZys.Model;
using Spectre.Console;

namespace Flashcards.KacperZys.Controller;
internal class StacksController
{
    StacksModel stacksModel = new();

    internal void Create()
    {
        string stackName = AnsiConsole.Ask<string>("Enter name for your stack:");
        stacksModel.Create(new StackDTO { Name = stackName });
    }

    internal void Delete()
    {
        string stackName = AnsiConsole.Ask<string>("Enter name of the stack to delete:");
        // TODO: Check if stack exists
        bool toDelete = AnsiConsole.Confirm($"Are you sure you want to delete {stackName}?");

        if (toDelete)
            stacksModel.Delete(new StackDTO { Name = stackName });
    }

    internal void DisplayStacks()
    {
        List<StackDTO> stacks = stacksModel.GetAllStacks();
        Table table = new();
        table.AddColumn("Name");

        for (int i = 0; i < stacks.Count; i++)
        {
            table.AddRow(stacks[i].Name);
        }

        AnsiConsole.Write(table);
    }

    internal void Modify()
    {
        throw new NotImplementedException();
    }
}
