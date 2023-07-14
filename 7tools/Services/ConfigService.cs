using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tools.Models;

namespace SvTools.Services;

public class ConfigService
{
    private readonly string _fileName;

    public ConfigService(string fileName)
    {
        _fileName = $"{fileName}.json";
    }

    public void CreateConfigIfNotExists()
    {
        File.Create(_fileName);
    }

    public Language[] LoadLanguagesFromConfig(Language[] languages)
    {
        var modifiedLanguages = new List<Language>();
        var jsonLanguages = JObject.Parse(File.ReadAllText(_fileName));
        foreach (var language in languages)
        {
            var languageFromJson = JsonConvert.DeserializeObject<Language>(jsonLanguages[language.Id + ""].ToString());
            if (languageFromJson is not null)
            {
                language.InstalledVersion = languageFromJson.InstalledVersion;
                language.DownloadPath = languageFromJson.DownloadPath;
                language.IsChecked = languageFromJson.IsChecked;
                language.ShouldBeEnvironmentVariable = languageFromJson.IsChecked;
            }
            modifiedLanguages.Add(language);
        }

        return modifiedLanguages.ToArray();
    }
}