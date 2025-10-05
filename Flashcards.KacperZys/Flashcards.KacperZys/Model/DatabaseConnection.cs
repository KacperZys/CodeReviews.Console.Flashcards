using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Spectre.Console;

namespace Flashcards.KacperZys.Model;
internal static class DatabaseConnection
{
    public static SqlConnection Connect()
    {
        string connectionString = GetConnectionString();

        return new SqlConnection(connectionString);
    }

    private static string GetConnectionString()
    {
        var config = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

        string? connectionString = config.GetConnectionString("SqlServer");

        if (string.IsNullOrEmpty(connectionString))
        {
            AnsiConsole.MarkupLine($"[red]No connection string found. Please configure your connection.[/]");
            Environment.Exit(0);
        }

        return connectionString;
    }
}
