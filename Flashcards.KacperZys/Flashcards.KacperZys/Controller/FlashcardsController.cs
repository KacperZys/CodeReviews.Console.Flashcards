using Flashcards.KacperZys.Model;
using Spectre.Console;

namespace Flashcards.KacperZys.Controller;
internal class FlashcardsController
{
    FlashcardsModel flashcardsModel = new();
    private static StackDTO? CurrentStack { get; set; }

    internal void Create()
    {
        string frontText = AnsiConsole.Ask<string>("[green]Please provide front of the flashcard: [/]");
        string backText = AnsiConsole.Ask<string>("[green]Please provide back of the flashcard: [/]");

        flashcardsModel.Create(new FlashcardDTO() { Front = frontText, Back = backText });
    }

    internal void Delete()
    {
        throw new NotImplementedException();
    }

    internal void Display()
    {
        flashcardsModel.GetAllFlashcards();
    }

    internal void Modify()
    {
        throw new NotImplementedException();
    }

    public static StackDTO GetCurrentStack()
    {
        if (CurrentStack == null)
        {
            AnsiConsole.MarkupLine("[red]You haven't selected a stack yet![/]");
            SetCurrentStack();
        }

        return CurrentStack!;
    }

    public static void SetCurrentStack()
    {
        var stacks = SharedOptionsModel.GetAllStacks();
        List<string> stacksNames = new();
        foreach (var stack in stacks)
        {
            stacksNames.Add(stack.Name);
        }
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select Stack")
            .AddChoices(stacksNames));
        CurrentStack = new StackDTO { Name = selection };
        AnsiConsole.MarkupLine($"You have chosed {selection}");
    }
}
