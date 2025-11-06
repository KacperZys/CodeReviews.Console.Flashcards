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
        bool stackExists = stacksModel.Exists(new StackDTO { Name = stackName });

        if (!stackExists)
        {
            AnsiConsole.MarkupLine("[red]There's no stack with that name! Please try again.[/]");
            return;
        }

        bool deleteCheck = AnsiConsole.Confirm($"Are you sure you want to delete {stackName}?");

        if (deleteCheck)
            stacksModel.Delete(new StackDTO { Name = stackName });
    }

    internal void Display()
    {
        List<StackDTO> stacks = SharedOptionsModel.GetAllStacks();
        Table table = new();
        table.ShowRowSeparators();
        table.AddColumn("Name");

        for (int i = 0; i < stacks.Count; i++)
        {
            table.AddRow(stacks[i].Name);
        }

        AnsiConsole.Write(table);
    }

    internal void Modify()
    {
        string stackName = AnsiConsole.Ask<string>("Enter name of the stack to modify:");
        bool stackExists = stacksModel.Exists(new StackDTO { Name = stackName });

        if (!stackExists)
        {
            AnsiConsole.MarkupLine("[red]There's no stack with that name! Please try again.[/]");
            return;
        }

        string newName = AnsiConsole.Ask<string>("Enter new name for stack:");
        stacksModel.Modify(new StackDTO { Name = newName }, stackName);
        AnsiConsole.MarkupLine("[red]New name has been set[/]");
    }
}
