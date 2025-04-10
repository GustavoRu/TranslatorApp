using System.Net.Http;
using System.Text.Json;
using TranslatorApp.DTOs;

namespace TranslatorApp.Services
{
    public class LyricsService : ILyricsService
    {
        private readonly HttpClient _httpClient;

        public LyricsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> GetLyricsAsync(string artist, string title)
        {
            var url = "https://api.lyrics.ovh/v1/" + artist + "/" + title;
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<LyricsResponseDto>(json);

                return result?.Lyrics;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
                return null;
            }

        }

    }
}