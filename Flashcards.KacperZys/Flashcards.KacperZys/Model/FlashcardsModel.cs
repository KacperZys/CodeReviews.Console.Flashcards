using Dapper;
using Flashcards.KacperZys.Controller;

namespace Flashcards.KacperZys.Model;
internal class FlashcardsModel
{
    internal void Create(FlashcardDTO flashcard)
    {
        var connection = DatabaseConnection.Connect();
        StackDTO stack = FlashcardsController.GetCurrentStack();
        string query = "INSERT INTO Flashcards (Front, Back) VALUES (@Front, @Back);";
        connection.Execute(query, flashcard);
    }

    internal List<FlashcardDTO> GetAllFlashcards()
    {
        var connection = DatabaseConnection.Connect();
        StackDTO stack = FlashcardsController.GetCurrentStack();
        string query = $"SELECT * FROM Stack WHERE Name = {stack}";

        return connection.Query<FlashcardDTO>(query, new FlashcardDTO()).ToList();
    }
}
