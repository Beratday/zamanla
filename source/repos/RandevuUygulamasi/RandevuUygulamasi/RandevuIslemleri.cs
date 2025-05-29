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
            string query = "SELECT * FROM Randevular";
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
}
