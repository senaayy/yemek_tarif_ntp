using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using YemekTarifiApp.Models;

namespace Modul.Service
{
    public class MySqlTarifRepository
    {
        private readonly string _connectionString;

        public MySqlTarifRepository()
        {
            // App.config içinden bağlantı dizesini alıyoruz
            _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new Exception("App.config içinde 'MySqlConnectionString' bulunamadı!");
            }
        }

        /// <summary>
        /// Yeni bir tarifi tüm besin değerleriyle favorilere ekler.
        /// </summary>
        public void FavoriEkle(TarifResponse tarif)
        {
            if (tarif == null) throw new ArgumentNullException(nameof(tarif));

            const string sql = @"INSERT INTO tarif_favori 
                                (baslik, malzemeler, tarif_metin, kalori, protein, karbonhidrat, eklenme_tarihi)
                                 VALUES 
                                (@baslik, @malzemeler, @tarif_metin, @kalori, @protein, @karbonhidrat, NOW());";

            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@baslik", tarif.TarifAdi);
                cmd.Parameters.AddWithValue("@malzemeler", tarif.Malzemeler);
                cmd.Parameters.AddWithValue("@tarif_metin", tarif.Yapilis);
                cmd.Parameters.AddWithValue("@kalori", (int)tarif.Kalori);
                cmd.Parameters.AddWithValue("@protein", (int)tarif.Protein);
                cmd.Parameters.AddWithValue("@karbonhidrat", (int)tarif.Karbonhidrat);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Veritabanındaki tüm favori tarifleri detaylıca çeker.
        /// </summary>
        public List<TarifResponse> GetTumFavoriler()
        {
            var liste = new List<TarifResponse>();
            const string sql = "SELECT baslik, malzemeler, tarif_metin, kalori, protein, karbonhidrat FROM tarif_favori ORDER BY eklenme_tarihi DESC;";

            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new TarifResponse
                        {
                            TarifAdi = reader.IsDBNull(0) ? "" : reader.GetString(0),
                            Malzemeler = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            Yapilis = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            Kalori = reader.IsDBNull(3) ? 0 : reader.GetDouble(3),
                            Protein = reader.IsDBNull(4) ? 0 : reader.GetDouble(4),
                            Karbonhidrat = reader.IsDBNull(5) ? 0 : reader.GetDouble(5)
                        });
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Başlığa göre favori tarifi siler.
        /// </summary>
        public void FavoriSil(string baslik)
        {
            const string sql = "DELETE FROM tarif_favori WHERE baslik = @baslik";
            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@baslik", baslik);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}