using Flashcards.KacperZys.Model;
using Spectre.Console;

namespace Flashcards.KacperZys.Controller;
internal class FlashcardsController
{
    FlashcardsModel flashcardsModel = new();
    private static Stack? CurrentStack { get; set; }

    internal void Create()
    {
        string frontText = AnsiConsole.Ask<string>("[green]Please provide front of the flashcard: [/]");
        string backText = AnsiConsole.Ask<string>("[green]Please provide back of the flashcard: [/]");

        flashcardsModel.Create(new FlashcardDTO() { Front = frontText, Back = backText });
        AnsiConsole.MarkupLine("[green]New card has been added![/]");
    }

    internal void Delete()
    {
        throw new NotImplementedException();
    }

    internal void Display()
    {
        List<FlashcardDTO> flashcards = flashcardsModel.GetAllFlashcards();
        Table table = new();
        table.ShowRowSeparators();
        table.AddColumns("Front", "Back");

        foreach (FlashcardDTO flashcard in flashcards)
        {
            table.AddRow(flashcard.Front, flashcard.Back);
        }

        AnsiConsole.Write(table);
    }

    internal void Modify()
    {
        throw new NotImplementedException();
    }

    public static Stack GetCurrentStack()
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

        CurrentStack = SharedOptionsModel.GetStackByName(selection);
    }
}
