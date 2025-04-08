using TranslatorApp.DTOs;
// using TranslatorApp.Models;

namespace TranslatorApp.Services
{
    public interface ITranslationService
    {
        Task<TranslationResponseDto> TranslateAsync(TranslationRequestDto request);
    }
}