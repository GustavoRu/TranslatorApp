using TranslatorApp.DTOs;

namespace TranslatorApp.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslationProvider _translationProvider;

        public TranslationService(ITranslationProvider translationProvider)
        {
            _translationProvider = translationProvider;
        }

        public async Task<TranslationResponseDto> TranslateAsync(TranslationRequestDto request)
        {
            var dto = new DeepLRequestDto
            {
                Text = request.Lyrics,
                SourceLang = "ES",
                TargetLang = "EN"
            };

            var translated = await _translationProvider.TranslateTextAsync(dto);

            return new TranslationResponseDto
            {
                TranslatedLyrics = translated ?? "(error traduciendo)"
            };
        }
    }
}