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

        public TranslatorController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpPost("translate")]
        public async Task<ActionResult<TranslationResponseDto>> Translate([FromBody] TranslationRequestDto request)
        {
            var result = await _translationService.TranslateAsync(request);
            return Ok(result);

        }
    }
}