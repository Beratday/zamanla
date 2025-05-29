private void Form1_Load(object sender, EventArgs e)
{
    DatabaseHelper.InitializeDatabase();
    Listele();
}

private void Listele()
{
    var randevular = RandevuIslemleri.RandevuListele();
    listView1.Items.Clear();

    foreach (var r in randevular)
    {
        var item = new ListViewItem(r.Id.ToString());
        item.SubItems.Add(r.Baslik);
        item.SubItems.Add(r.Tarih.ToString("g"));
        listView1.Items.Add(item);
    }
}
