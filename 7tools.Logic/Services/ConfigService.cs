using Tools.Models;

namespace SvTools.Services;

public class ConfigService
{
    private readonly LanguageService _language;
    private readonly SettingsService _settings;

    public ConfigService(LanguageService language, SettingsService settings)
    {
        _language = language;
        _settings = settings;
    }
    

    public async Task<Language[]> GetLanguages(string endpoint)
    {
        var languagesFromHttp = await _language.GetLanguagesFromHttp($"{endpoint}");
        return _language.ModifyLanguagesFromFile(languagesFromHttp);
    }

    // public void ModifyLocalLanguage()
    // {
    //     
    // }

    public Settings GetSettings()
    {
        return _settings.LoadSettings();
    }
    
    // public void ModifySettings()
    // {
    //     
    // }

}