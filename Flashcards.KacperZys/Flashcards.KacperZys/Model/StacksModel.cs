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

    internal bool Exists(StackDTO stack)
    {
        var connection = DatabaseConnection.Connect();
        string query = "SELECT Name FROM Stack WHERE Name = @Name";
        var names = connection.Query<string>(query, stack);

        return names.Any();
    }



    internal void Modify(StackDTO stack, string oldName)
    {
        var connection = DatabaseConnection.Connect();
        string query = $"UPDATE Stack SET Name = @Name WHERE Name = '{oldName}';";
        connection.Execute(query, stack);
    }
}
