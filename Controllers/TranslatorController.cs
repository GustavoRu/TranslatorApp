using Microsoft.AspNetCore.Mvc;
using TranslatorApp.DTOs;
using TranslatorApp.Services;

namespace TranslatorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslatorController : ControllerBase
    {
        private readonly ITranslationService _translationService;
        private readonly ILyricsService _lyricsService;

        public TranslatorController(ITranslationService translationService, ILyricsService lyricsService)
        {
            _translationService = translationService;
            _lyricsService = lyricsService;
        }

        [HttpPost("translate")]
        public async Task<ActionResult<TranslationResponseDto>> Translate([FromBody] TranslationRequestDto request)
        {
            var result = await _translationService.TranslateAsync(request);
            return Ok(result);

        }

        [HttpGet("lyrics")]
        public async Task<ActionResult<string>> GetLyrics([FromQuery] string artist, [FromQuery] string title)
        {

            var lyrics = await _lyricsService.GetLyricsAsync(artist, title);
            if (lyrics == null)
                return NotFound("Letra no encontrada");

            return Ok(lyrics);
        }
    }
}