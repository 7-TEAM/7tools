using Newtonsoft.Json;
using Tools.Models;

namespace SvTools.Services;

public class LanguageService
{
    private readonly IFileService _file;
    private readonly string _fileName;
    private readonly IHttpService _http;

    public LanguageService(IFileService file, IHttpService http, string fileName)
    {
        _file = file;
        _http = http;
        _fileName = fileName;
    }

    public async Task<Language[]> GetLanguages(string endpoint)
    {
        var languagesFromHttp = await GetLanguagesFromHttp($"{endpoint}");
        return ModifyLanguagesFromFile(languagesFromHttp);
    }

    private async Task<Language[]> GetLanguagesFromHttp(string endpoint)
    {
        string response;
        try
        {
            response = await _http.SendGet(endpoint);
        }
        catch (IOException)
        {
            return null;
        }

        var jsonResponse = _file.ReadJson(response);
        return JsonConvert.DeserializeObject<List<Language>>(jsonResponse.ToString()).ToArray();
    }

    private Language[] ModifyLanguagesFromFile(Language[] languages)
    {
        _file.CreateFileIfNotExists(_fileName);
        var jsonLanguages = _file.ReadJson(_file.ReadContent(_fileName));
        var modifiedLanguages = new List<Language>();
        foreach (var language in languages)
        {
            var localLanguageSettings = language.LocalLanguageSettings;
            var localLanguageSettingsFromJson =
                JsonConvert.DeserializeObject<LocalLanguageSettings>(jsonLanguages[language.Id + ""].ToString());
            if (localLanguageSettingsFromJson is not null)
            {
                localLanguageSettings.InstalledVersion = localLanguageSettingsFromJson.InstalledVersion;
                localLanguageSettings.DownloadPath = localLanguageSettingsFromJson.DownloadPath;
                localLanguageSettings.IsChecked = localLanguageSettingsFromJson.IsChecked;
                localLanguageSettings.ShouldBeEnvironmentVariable = localLanguageSettingsFromJson.IsChecked;
            }

            modifiedLanguages.Add(language);
        }

        return modifiedLanguages.ToArray();
    }
}