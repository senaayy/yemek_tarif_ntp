using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YemekTarifiApp.Models;

namespace Modul.Service
{
    public class SGeminiAsistan : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiUrl;

        public SGeminiAsistan()
        {
            _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(60) };
            _apiKey = ConfigurationManager.AppSettings["GeminiApiKey"];
            _apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent";

            if (string.IsNullOrEmpty(_apiKey) || _apiKey == "YOUR_GEMINI_API_KEY")
                throw new Exception("Lütfen App.config dosyasına geçerli bir API Key ekleyin.");
        }

        public async Task<TarifResponse> GetTarifOnerisi(string malzemeListesi, string imagePath = null)
        {
            var parts = new List<object>();

            // Prompt oluşturma
            string prompt = "Bu fotoğraftaki malzemeleri analiz et ve bunlarla yapılabilecek bir tarif öner. ";
            if (!string.IsNullOrEmpty(malzemeListesi)) prompt += $"Ek olarak şu malzemelerim de var: {malzemeListesi}. ";

            prompt += @"Yanıtı SADECE saf JSON formatında dön: 
                       {""TarifAdi"": ""..."",""Malzemeler"": ""..."",""Yapilis"": ""..."",""Kalori"": 0,""Protein"": 0,""Karbonhidrat"": 0}";

            parts.Add(new { text = prompt });

            // Eğer fotoğraf varsa Base64'e çevirip ekle
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                string base64Image = Convert.ToBase64String(imageBytes);
                parts.Add(new { inline_data = new { mime_type = "image/jpeg", data = base64Image } });
            }

            var requestBody = new
            {
                contents = new[] { new { parts = parts.ToArray() } },
                generationConfig = new { response_mime_type = "application/json" }
            };

            string jsonContent = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_apiUrl}?key={_apiKey}", content);
            string responseJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"API Hatası: {response.StatusCode}. Detay: {responseJson}");

            dynamic result = JsonConvert.DeserializeObject(responseJson);
            string jsonString = result.candidates[0].content.parts[0].text;
            jsonString = jsonString.Replace("```json", "").Replace("```", "").Trim();

            return JsonConvert.DeserializeObject<TarifResponse>(jsonString);
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}