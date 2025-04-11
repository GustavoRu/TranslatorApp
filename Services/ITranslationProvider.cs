using TranslatorApp.DTOs;

namespace TranslatorApp.Services
{
    public interface ITranslationProvider
    {
        Task<string?> TranslateTextAsync(DeepLRequestDto request);
    }
}
