using System.Text.Json.Serialization;
namespace TranslatorApp.DTOs
{
    public class DeepLRequestDto
    {
        public string Text { get; set; } = string.Empty;
        public string SourceLang { get; set; } = "ES";
        public string TargetLang { get; set; } = "EN";
    }
}