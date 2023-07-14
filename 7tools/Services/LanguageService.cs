using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tools.Models;

namespace SvTools.Services;

public class LanguageService
{
    private readonly IFileService _file;
    private readonly IHttpService _http;
    private const string Url = "https://xyz.pl/api/";

    public LanguageService(IFileService file, IHttpService http)
    {
        _file = file;
        _http = http;
    }


    
    public async Task<Language[]> GetLanguages(string endpoint, string fileName)
    {
        var languagesFromHttp = GetLanguagesFromHttp($"{Url}{endpoint}");
        return ModifyLanguagesFromFile(await languagesFromHttp, fileName);
    }

    private async Task<Language[]> GetLanguagesFromHttp(string url)
    {
        string response;
        try
        {
            response = await _http.SendGet(url);
        }
        catch (IOException)
        {
            return null;
        }

        var jsonResponse = _file.ReadJson(response);
        return JsonConvert.DeserializeObject<List<Language>>(jsonResponse.ToString()).ToArray();
    }

    private Language[] ModifyLanguagesFromFile(Language[] languages, string fileName)
    {
        _file.CreateFileIfNotExists();
        var jsonLanguages = _file.ReadJson(_file.ReadContent(fileName));
        var modifiedLanguages = new List<Language>();
        foreach (var language in languages)
        {
            var languageFromJson = JsonConvert.DeserializeObject<Language>(jsonLanguages[language.Id + ""].ToString());
            if (languageFromJson is not null)
            {
                language.InstalledVersion = languageFromJson.InstalledVersion;
                language.DownloadPath = languageFromJson.DownloadPath;
                language.IsChecked = languageFromJson.IsChecked;
                language.ShouldBeEnvironmentVariable = languageFromJson.IsChecked;
                language.Bit = languageFromJson.Bit;
            }
            modifiedLanguages.Add(language);
        }
        
        return modifiedLanguages.ToArray();
    }
}