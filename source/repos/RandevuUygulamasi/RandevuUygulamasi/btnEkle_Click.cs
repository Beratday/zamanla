using System.Windows.Forms;

private void btnEkle_Click(object sender, EventArgs e)
{
    var randevu = new Randevu
    {
        Baslik = txtBaslik.Text,
        Aciklama = txtAciklama.Text,
        Tarih = dateTimePicker1.Value
    };

    RandevuIslemleri.RandevuEkle(randevu);
    Listele();
}
