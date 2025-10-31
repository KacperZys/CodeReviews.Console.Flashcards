using Dapper;

namespace Flashcards.KacperZys.Model;
internal class StacksModel
{
    internal void Create(StackDTO stack)
    {
        var connection = DatabaseConnection.Connect();
        string query = "INSERT INTO Stack (Name) VALUES (@Name);";
        connection.Execute(query, stack);
    }

    internal void Delete(StackDTO stack)
    {
        var connection = DatabaseConnection.Connect();
        string query = "DELETE FROM Stack WHERE Name = @Name";
        connection.Execute(query, stack);
    }

    internal List<StackDTO> GetAllStacks()
    {
        var connection = DatabaseConnection.Connect();
        string query = "SELECT * FROM Stack;";
        return connection.Query<StackDTO>(query, new StackDTO()).ToList();
    }
}
