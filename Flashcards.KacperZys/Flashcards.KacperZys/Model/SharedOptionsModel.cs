using Dapper;

namespace Flashcards.KacperZys.Model;
internal static class SharedOptionsModel
{
    internal static List<StackDTO> GetAllStacks()
    {
        var connection = DatabaseConnection.Connect();
        string query = "SELECT * FROM Stack;";
        return connection.Query<StackDTO>(query, new StackDTO()).ToList();
    }

    internal static Stack GetStackByName(string name)
    {
        var connection = DatabaseConnection.Connect();
        string query = $"SELECT Stack_Id, Name FROM Stack WHERE Name = @Name";
        return connection.QuerySingle<Stack>(query, new { Name = name });
    }
}
