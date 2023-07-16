using SvTools.Models;

namespace SvTools.Services;

public interface ILanguageService
{
    Task<Language[]> GetLanguages(string endpoint);
    void UpdateLocalLanguage(Language language, LocalLanguage toChange);
}