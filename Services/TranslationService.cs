using TranslatorApp.DTOs;

namespace TranslatorApp.Services
{
    public class TranslationService : : ITranslationService
    {
        // private readonly ITranslationProvider _translationProvider;

        // public TranslationService(ITranslationProvider translationProvider)
        // {
        //     _translationProvider = translationProvider;
        // }

        public async Task<TranslationResponseDto> TranslateAsync(TranslationRequestDto request)
    {
        // Versión dummy
        return await Task.FromResult(new TranslationResponseDto
        {
            TranslatedLyrics = request.Lyrics + " (translated to English)"
        });
    }
}
}