using SvTools.Models;

namespace SvTools.Services;

public interface ILanguageService
{
    Task<Language[]> GetLanguagesAsync(string endpoint);
    Task<Language> UpdateLocalLanguageAsync(Language language, LocalLanguage toChange);
    Language[] GetLanguagesToUpdate(Language[] oldLanguages, Language[] currentLanguages);
}