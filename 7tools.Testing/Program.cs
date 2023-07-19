using SvTools.Models;
using SvTools.Models.Extensions;
using SvTools.Services;
using SvTools.Services.DataAccess;
using SvTools.Services.WebAccess;
using Version = SvTools.Models.Version;

const string fileName = "config.json";
var httpService = new HttpService(new HttpClient());
var languageService = new LanguageService(new FileService(), httpService, fileName);
var downloadService = new DownloadService(httpService);
//to powinno byc co jakis czas, zeby aktualizowac gui

var languages =
    await languageService.GetLanguagesAsync(
        $"api/languages?platform={RuntimeInformationExtensions.PlatformName()}");
var languagesToUpdate = languageService.GetLanguagesToUpdate(languages, await languageService.GetLanguagesAsync(
    $"api/languages?platform={RuntimeInformationExtensions.PlatformName()}"));
foreach (var language in languagesToUpdate)
{
    await downloadService.DownloadLanguageAsync(language);
    await languageService.UpdateLocalLanguageAsync(language, language.LocalLanguage);
}
  
    // var language = languages.First();
    // var newLanguage = await languageService.UpdateLocalLanguageAsync(language, new LocalLanguage
    // {
    //     PickedVersion = new Version()
    //     {
    //         Iteration = "3.2"
    //     },
    //     IsChecked = true,
    //     ShouldBeEnvironmentVariable = true
    // });
    // languages[Array.FindIndex(languages, l => l.Id == language.Id)] = newLanguage;
