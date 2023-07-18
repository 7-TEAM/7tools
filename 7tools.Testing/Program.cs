using SvTools.Models;
using SvTools.Models.Extensions;
using SvTools.Services;
using SvTools.Services.DataAccess;
using SvTools.Services.WebAccess;

const string fileName = "config.json";
var httpService = new HttpService(new HttpClient());
var languageService = new LanguageService(new FileService(), httpService, fileName);
var downloadService = new DownloadService(httpService);
//to powinno byc co jakis czas, zeby aktualizowac gui
try
{
    var languages =
        await languageService.GetLanguagesAsync(
            $"api/languages?platform={RuntimeInformationExtensions.PlatformName()}");
    var language = languages.First();
    var newLanguage = await languageService.UpdateLocalLanguage(language, new LocalLanguage
    {
        IsChecked = true,
        ShouldBeEnvironmentVariable = true
    });
    languages[Array.FindIndex(languages, l => l.Id == language.Id)] = newLanguage;
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    //coś poszło nie tak przy pobieraniu języków
}