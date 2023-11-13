using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string klasorYolu = @"C:\Users\BerkerOsanc.YYTPBERKEROSANC\Desktop\test";

        string[] dosyaListesi = Directory.GetFiles(klasorYolu);

        foreach (var dosyaYolu in dosyaListesi)
        {
            DuzenleVeYenidenAdlandir(dosyaYolu);
        }

        Console.WriteLine("İşlem tamamlandı. Programı kapatmak için bir tuşa basın.");
        Console.ReadKey();
    }

    static void DuzenleVeYenidenAdlandir(string dosyaYolu)
    {
        try
        {
            string dosyaAdi = Path.GetFileNameWithoutExtension(dosyaYolu);
            string dosyaUzantisi = Path.GetExtension(dosyaYolu);

            string duzenlenmisAd = string.Join("-", dosyaAdi.Split(' ')).ToLower();

            duzenlenmisAd = TurkceToIngilizce(duzenlenmisAd);

            string yeniDosyaAdi = $"{duzenlenmisAd}{dosyaUzantisi}";

            File.Move(dosyaYolu, Path.Combine(Path.GetDirectoryName(dosyaYolu), yeniDosyaAdi));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata oluştu: {ex.Message}");
        }
    }

    static string TurkceToIngilizce(string metin)
    {
        string[] turkceKarakterler = { "ğ", "ü", "ş", "ı", "i", "ö", "ç", "Ğ", "Ü", "Ş", "I", "İ", "Ö", "Ç" };
        string[] ingilizceKarakterler = { "g", "u", "s", "i", "i", "o", "c", "G", "U", "S", "I", "I", "O", "C" };

        for (int i = 0; i < turkceKarakterler.Length; i++)
        {
            metin = metin.Replace(turkceKarakterler[i], ingilizceKarakterler[i]);
        }

        return metin;
    }
}
