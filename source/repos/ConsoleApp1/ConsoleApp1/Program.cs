using System;
using System.Collections.Generic;

namespace RandevuUygulamasi
{
    class Randevu
    {
        public int Id { get; set; }
        public string KisiAdi { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
    }

    class Program
    {
        static List<Randevu> randevular = new List<Randevu>();
        static int idSayaci = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== RANDEVU UYGULAMASI ===");
                Console.WriteLine("1. Randevu Ekle");
                Console.WriteLine("2. Randevuları Listele");
                Console.WriteLine("3. Randevu Sil");
                Console.WriteLine("4. Çıkış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        RandevuEkle();
                        break;
                    case "2":
                        RandevuListele();
                        break;
                    case "3":
                        RandevuSil();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break;
                }
            }
        }

        static void RandevuEkle()
        {
            Console.Write("Kişi Adı: ");
            string ad = Console.ReadLine();

            Console.Write("Randevu Tarihi (gg.aa.yyyy ss:dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime tarih))
            {
                Console.WriteLine("Geçersiz tarih formatı!");
                return;
            }

            Console.Write("Açıklama: ");
            string aciklama = Console.ReadLine();

            Randevu yeniRandevu = new Randevu
            {
                Id = idSayaci++,
                KisiAdi = ad,
                Tarih = tarih,
                Aciklama = aciklama
            };

            randevular.Add(yeniRandevu);
            Console.WriteLine("Randevu başarıyla eklendi.");
        }

        static void RandevuListele()
        {
            if (randevular.Count == 0)
            {
                Console.WriteLine("Henüz randevu yok.");
                return;
            }

            foreach (var randevu in randevular)
            {
                Console.WriteLine($"\nID: {randevu.Id}");
                Console.WriteLine($"Kişi: {randevu.KisiAdi}");
                Console.WriteLine($"Tarih: {randevu.Tarih}");
                Console.WriteLine($"Açıklama: {randevu.Aciklama}");
            }
        }

        static void RandevuSil()
        {
            Console.Write("Silmek istediğiniz randevunun ID'sini girin: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Geçersiz ID!");
                return;
            }

            var randevu = randevular.Find(r => r.Id == id);
            if (randevu == null)
            {
                Console.WriteLine("Randevu bulunamadı.");
                return;
            }

            randevular.Remove(randevu);
            Console.WriteLine("Randevu silindi.");
        }
    }
}
