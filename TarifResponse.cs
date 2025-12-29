namespace YemekTarifiApp.Models
{
    // Gemini'den gelen verileri karşılayan model sınıfı [Kaynak: Sistem Tasarımı]
    public class TarifResponse
    {
        public string TarifAdi { get; set; }
        public string Malzemeler { get; set; }
        public string Yapilis { get; set; }
        public int Kalori { get; set; }
        public int Protein { get; set; }
        public int Karbonhidrat { get; set; }
    }
}