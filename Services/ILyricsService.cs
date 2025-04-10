namespace TranslatorApp.Services
{
    public interface ILyricsService
    {
        Task<string?> GetLyricsAsync(string artist, string title);
    }
}