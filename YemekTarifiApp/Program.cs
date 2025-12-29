using System;
using System.Windows.Forms;

namespace YemekTarifiApp
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana giriş noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Burada FrmTarifOneri formunu başlatıyoruz
            // Eğer formun ismini değiştirdiyseniz (örn: Form1), burayı da ona göre güncelleyin.
            Application.Run(new FrmTarifOneri());
        }
    }
}