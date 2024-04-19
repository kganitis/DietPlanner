using System;
using System.Data.SQLite;

internal static class DBConnectionManager
{
    private static readonly string connectionString = "Data source=DietPlanner.db;Version=3;";
    private static SQLiteConnection connection;

    static DBConnectionManager()
    {
        connection = new SQLiteConnection(connectionString);
    }

    public static string ConnectionString { get { return connectionString; } }

    public static SQLiteConnection GetConnection()
    {
        if (connection.State != System.Data.ConnectionState.Open)
        {
            try
            {
                connection.Open();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Error opening connection: {ex.Message}");
            }
        }
        return connection;
    }

    public static void CloseConnection()
    {
        if (connection.State != System.Data.ConnectionState.Closed)
        {
            try
            {
                connection.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Error closing connection: {ex.Message}");
            }
        }
    }
}
