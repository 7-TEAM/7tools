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

    public async Task<Language[]> GetLanguagesAsync(string endpoint)
    {
        var languagesFromHttp = await GetLanguagesFromHttpAsync($"{endpoint}");
        return await ModifyLanguagesFromFile(languagesFromHttp);
    }

    public async Task<Language> UpdateLocalLanguage(Language language, LocalLanguage toChange)
    {
        var jsonLocalLanguages = await ReadLocalLanguages();
        language.LocalLanguage = toChange;
        jsonLocalLanguages[language.Id + ""] = JsonConvert.SerializeObject(language.LocalLanguage, Formatting.None);
        await _file.WriteAsync(_fileName, jsonLocalLanguages.ToString());
        return language;
    }

    private async Task<JObject> ReadLocalLanguages()
    {
        if (!File.Exists(_fileName)) await _file.WriteAsync(_fileName, "{}");
        return _file.ReadJsonObject(await _file.ReadContentAsync(_fileName));
    }

    private async Task<Language[]> GetLanguagesFromHttpAsync(string endpoint)
    {
        string response;
        response = await _http.SendGet(endpoint);
        var jsonResponse = _file.ReadJsonArray(response);
        return JsonConvert.DeserializeObject<Language[]>(jsonResponse.ToString());
    }

    private LocalLanguage? GetLocalLanguage(Language language, JObject jObject)
    {
        var jsonLocalLanguage = jObject[language.Id + ""];
        return jsonLocalLanguage is null
            ? null
            : JsonConvert.DeserializeObject<LocalLanguage>(jsonLocalLanguage.ToString());
    }

    private async Task<Language[]> ModifyLanguagesFromFile(Language[] languages)
    {
        var jsonLocalLanguages = await ReadLocalLanguages();
        var modifiedLanguages = new List<Language>();
        foreach (var language in languages)
        {
            var localLanguage = GetLocalLanguage(language, jsonLocalLanguages);
            if (localLanguage is not null) language.LocalLanguage = localLanguage;
            modifiedLanguages.Add(language);
        }

        return modifiedLanguages.ToArray();
    }
}