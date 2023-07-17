using SvTools.Models;
using SvTools.Models.Extensions;
using SvTools.Services;
using SvTools.Services.DataAccess;
using SvTools.Services.WebAccess;

const string fileName = "config.json";
var languageService = new LanguageService(new FileService(), new HttpService(new HttpClient()), fileName);
//to powinno byc co jakis czas, zeby aktualizowac gui
try
{
    var languages =
        await languageService.GetLanguages($"api/languages?platform={RuntimeInformationExtensions.PlatformName()}");
    var language = languages.First();
    languageService.UpdateLocalLanguage(ref language, new LocalLanguage
    {
        IsChecked = true,
        ShouldBeEnvironmentVariable = true
    });
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    //coś poszło nie tak przy pobieraniu języków
}