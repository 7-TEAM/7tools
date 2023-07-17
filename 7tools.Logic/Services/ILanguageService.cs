using SvTools.Models;

namespace SvTools.Services;

public interface ILanguageService
{
    Task<Language[]> GetLanguagesAsync(string endpoint);
    void UpdateLocalLanguage(ref Language language, LocalLanguage toChange);
}