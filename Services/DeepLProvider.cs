using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using TranslatorApp.DTOs;

namespace TranslatorApp.Services
{
    public class DeepLProvider : ITranslationProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public DeepLProvider(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["DeepL:ApiKey"] ?? throw new Exception("API Key de DeepL no encontrada");

            _httpClient.BaseAddress = new Uri("https://api-free.deepl.com/v2/");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("DeepL-Auth-Key", _apiKey);
        }

        public async Task<string?> TranslateTextAsync(DeepLRequestDto request)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("text", request.Text),
                new KeyValuePair<string, string>("source_lang", request.SourceLang),
                new KeyValuePair<string, string>("target_lang", request.TargetLang)
            });

            var response = await _httpClient.PostAsync("translate", content);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<DeepLResponseDto>(responseString);
            Console.WriteLine("Result: " + responseString);
            return result?.Translations?.FirstOrDefault()?.Text;
        }
    }
}
