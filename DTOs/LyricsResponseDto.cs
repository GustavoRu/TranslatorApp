using System.Text.Json.Serialization;
namespace TranslatorApp.DTOs
{
    public class LyricsResponseDto
    {
        [JsonPropertyName("lyrics")]
        public string? Lyrics { get; set; }
    }
}