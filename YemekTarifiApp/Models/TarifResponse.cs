namespace YemekTarifiApp.Models
{
    public class TarifResponse
    {
        public string TarifAdi { get; set; }
        public string Malzemeler { get; set; }
        public string Yapilis { get; set; }
        public double Kalori { get; set; } // int yerine double yaptık
        public double Protein { get; set; } // int yerine double yaptık
        public double Karbonhidrat { get; set; } // int yerine double yaptık
    }
}