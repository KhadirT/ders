using System;
using System.Collections.Generic;

namespace Kadir
{
    class Program
    {
        static void Main(string[] args)
        {
            KitapYonetimi kitapYonetimi = new KitapYonetimi();
            while (true)
            {
                YapilacaklarListesi();
                var secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.WriteLine("Kitap eklemek için gerekli bilgileri giriniz:");
                        Console.Write("Kitap ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Kitap Adı: ");
                        string ad = Console.ReadLine();
                        Console.Write("Yazar: ");
                        string yazar = Console.ReadLine();
                        kitapYonetimi.KitapEkle(new Kitap(id, ad, yazar));
                        Console.WriteLine("Kitap eklendi.");
                        break;

                    case "2":
                        Console.Write("Silinecek Kitap ID: ");
                        int silinecekId = Convert.ToInt32(Console.ReadLine());
                        kitapYonetimi.KitapSil(silinecekId);
                        break;

                    case "3":
                        Console.Write("Aranacak Kitap Adı: ");
                        string aranacakAd = Console.ReadLine();
                        kitapYonetimi.KitapAra(aranacakAd);
                        break;

                    case "4":
                        kitapYonetimi.KitapListele();
                        break;

                    case "q":
                        Console.WriteLine("Programdan çıkılıyor.");
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                        break;
                }
            }
        }

        static void YapilacaklarListesi()
        {
            Console.WriteLine("\nYapılacaklar Listesi:");
            Console.WriteLine("1 - Kitap Ekleme");
            Console.WriteLine("2 - Kitap Silme");
            Console.WriteLine("3 - Kitap Arama");
            Console.WriteLine("4 - Kitapları Listeleme");
            Console.WriteLine("q - Çıkış");
            Console.Write("Seçiminizi yapınız: ");
        }
    }

    class Kitap
    {
        public Kitap(int id, string ad, string yazar)
        {
            KitapID = id;
            Ad = ad;
            Yazar = yazar;
        }

        public int KitapID { get; set; }
        public string Ad { get; set; }
        public string Yazar { get; set; }

        public string BilgiYazdir()
        {
            return $"ID: {KitapID}, Ad: {Ad}, Yazar: {Yazar}";
        }
    }

    class KitapYonetimi
    {
        private List<Kitap> kitaplar = new List<Kitap>();

        public void KitapEkle(Kitap kitap)
        {
            kitaplar.Add(kitap);
        }

        public void KitapListele()
        {
            if (kitaplar.Count == 0)
            {
                Console.WriteLine("Listeleyecek kitap yok.");
                return;
            }

            foreach (var kitap in kitaplar)
            {
                Console.WriteLine(kitap.BilgiYazdir());
            }
        }

        public void KitapSil(int id)
        {
            var kitap = kitaplar.Find(k => k.KitapID == id);
            if (kitap != null)
            {
                kitaplar.Remove(kitap);
                Console.WriteLine($"Kitap ID {id} silindi.");
            }
            else
            {
                Console.WriteLine("Silinecek kitap bulunamadı.");
            }
        }

        public void KitapAra(string ad)
        {
            var bulunanKitaplar = kitaplar.FindAll(k => k.Ad.IndexOf(ad, StringComparison.OrdinalIgnoreCase) >= 0);
            if (bulunanKitaplar.Count == 0)
            {
                Console.WriteLine("Arama kriterine uygun kitap bulunamadı.");
            }
            else
            {
                Console.WriteLine("Bulunan Kitaplar:");
                foreach (var kitap in bulunanKitaplar)
                {
                    Console.WriteLine(kitap.BilgiYazdir());
                }
            }
        }
    }
}
