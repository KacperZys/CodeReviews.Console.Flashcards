using Dapper;
using Flashcards.KacperZys.Controller;

namespace Flashcards.KacperZys.Model;
internal class FlashcardsModel
{
    internal void Create(FlashcardDTO flashcard)
    {
        var connection = DatabaseConnection.Connect();
        Stack stack = FlashcardsController.GetCurrentStack();
        string query = "INSERT INTO Flashcards (Front, Back, Stack_Id) VALUES (@Front, @Back, @Stack_Id);";
        connection.Execute(query, new { flashcard.Front, flashcard.Back, stack.Stack_Id });
    }

    internal List<FlashcardDTO> GetAllFlashcards()
    {
        var connection = DatabaseConnection.Connect();
        Stack stack = FlashcardsController.GetCurrentStack();
        string query = $"SELECT * FROM Flashcards WHERE Stack_Id = {stack.Stack_Id}";

        return connection.Query<FlashcardDTO>(query, new FlashcardDTO()).ToList();
    }
}
