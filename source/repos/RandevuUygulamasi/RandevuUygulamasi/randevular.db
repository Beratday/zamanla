using System.Data.SQLite;

public class DatabaseHelper
{
    private static string connectionString = "Data Source=randevular.db;Version=3;";

    public static void InitializeDatabase()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = @"CREATE TABLE IF NOT EXISTS Randevular (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Baslik TEXT NOT NULL,
                                Aciklama TEXT,
                                Tarih TEXT NOT NULL
                            );";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(connectionString);
    }
}
