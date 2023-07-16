using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SvTools.Models;
using SvTools.Services.DataAccess;
using SvTools.Services.WebAccess;

namespace SvTools.Services;

public class LanguageService : ILanguageService
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

    public void UpdateLocalLanguage(Language language, LocalLanguage toChange)
    {
        var jsonLocalLanguages = ReadLocalLanguagesSettings();
        language.LocalLanguage = toChange;
        jsonLocalLanguages[language.Id + ""] = JsonConvert.SerializeObject(language.LocalLanguage, Formatting.None);
        _file.Write(_fileName, jsonLocalLanguages.ToString());
    }

    private JObject ReadLocalLanguagesSettings()
    {
        if (_file.CreateFileIfNotExists(_fileName))
        {
            _file.Write(_fileName, "{}");
        }
        return _file.ReadJson(_file.ReadContent(_fileName));
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
            throw;
        }

        var jsonResponse = _file.ReadJson(response);
        return JsonConvert.DeserializeObject<List<Language>>(jsonResponse.ToString()).ToArray();
    }

    private LocalLanguage? GetLocalLanguage(Language language, JObject jObject)
    {
        var jsonLocalLanguage = jObject[language.Id + ""];
        return jsonLocalLanguage is null ? null : JsonConvert.DeserializeObject<LocalLanguage>(jsonLocalLanguage.ToString());
    }

    private Language[] ModifyLanguagesFromFile(Language[] languages)
    {
        var jsonLocalLanguages = ReadLocalLanguagesSettings();
        var modifiedLanguages = new List<Language>();
        foreach (var language in languages)
        {
            var localLanguage = GetLocalLanguage(language, jsonLocalLanguages);
            if (localLanguage is null) continue;
            language.LocalLanguage = localLanguage;
            modifiedLanguages.Add(language);
        
        }
        return modifiedLanguages.ToArray();
    }
}