using SvTools.Models;

namespace SvTools.Services;

public interface ILanguageService
{
    Task<Language[]> GetLanguagesAsync(string endpoint);
    Task<Language> UpdateLocalLanguage(Language language, LocalLanguage toChange);
}