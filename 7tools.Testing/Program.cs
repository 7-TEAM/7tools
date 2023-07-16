using System.Runtime.InteropServices;
using SvTools.Services;
using Tools.Models.Extensions;

const string fileName = "config.json";
var languageService = new LanguageService(new FileService(), new HttpService(new HttpClient()), fileName);

//to powinno byc wykonywane podczas zapisania aplikacji (gdy uzytkownik wcisnie przycisk zapisz) i co jakis czas, zeby aktualizowac gui
try
{
    var languages = await languageService.GetLanguages($"api/languages?platform={RuntimeInformationExtensions.PlatformName()}");
}
catch (NullReferenceException)
{
    //użytkownik ma niewykrywalny system
}
