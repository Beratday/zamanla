using System.Data.SQLite;

public static class RandevuIslemleri
{
    public static void RandevuEkle(Randevu r)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "INSERT INTO Randevular (Baslik, Aciklama, Tarih) VALUES (@b, @a, @t)";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@b", r.Baslik);
                cmd.Parameters.AddWithValue("@a", r.Aciklama);
                cmd.Parameters.AddWithValue("@t", r.Tarih.ToString("yyyy-MM-dd HH:mm"));
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static List<Randevu> RandevuListele()
    {
        var liste = new List<Randevu>();
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM Randevular ORDER BY Tarih";
            using (var cmd = new SQLiteCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    liste.Add(new Randevu
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Baslik = reader["Baslik"].ToString(),
                        Aciklama = reader["Aciklama"].ToString(),
                        Tarih = DateTime.Parse(reader["Tarih"].ToString())
                    });
                }
            }
        }
        return liste;
    }

    public static void RandevuSil(int id)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "DELETE FROM Randevular WHERE Id = @id";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static void RandevuGuncelle(Randevu r)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "UPDATE Randevular SET Baslik = @b, Aciklama = @a, Tarih = @t WHERE Id = @id";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@b", r.Baslik);
                cmd.Parameters.AddWithValue("@a", r.Aciklama);
                cmd.Parameters.AddWithValue("@t", r.Tarih.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@id", r.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    internal static void RandevuEkle(object randevu)
    {
        throw new NotImplementedException();
    }
}
