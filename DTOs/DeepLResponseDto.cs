using System.Text.Json.Serialization;

namespace TranslatorApp.DTOs
{
    public class DeepLResponseDto
    {
        [JsonPropertyName("translations")]
        public List<DeepLTranslationDto>? Translations { get; set; }
    }

    public class DeepLTranslationDto
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
