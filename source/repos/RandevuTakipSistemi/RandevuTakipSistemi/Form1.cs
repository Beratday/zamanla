private static void Listele()
{
    object listView1 = null;
    listView1.Items.Clear();
    var randevular = RandevuIslemleri.RandevuListele();

    foreach (var r in randevular)
    {
        var item = new ListViewItem(r.Id.ToString());
        item.SubItems.Add(r.Baslik);
        item.SubItems.Add(r.Tarih.ToString("g"));

        if (r.Tarih < DateTime.Now)
            item.BackColor = Color.LightGray; // Geçmiþ randevu
        else if ((r.Tarih - DateTime.Now).TotalHours < 24)
            item.BackColor = Color.LightSalmon; // Yaklaþan randevu

        object listView1 = null;
        listView1.Items.Add(item);
    }
}
private void Form1_Load(object sender, EventArgs e)
{
    DatabaseHelper.InitializeDatabase();
    Listele();
}
private void btnEkle_Click(object sender, EventArgs e)
{
    // ... kodlar ...
    RandevuIslemleri.RandevuEkle(randevu);
    Listele();
}
RandevuIslemleri.RandevuSil(id);
Listele();

RandevuIslemleri.RandevuGuncelle(r);
Listele();
