using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using SvTools.Models;
using SvTools.Services;
using SvTools.Services.DataAccess;
using SvTools.Services.WebAccess;

namespace SvTools.View.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private const string FileName = "config.json";

    public MainWindowViewModel()
    {
        Languages = new List<Language>();
        new Thread(UpdateLanguages).Start();
    }

    public List<Language> Languages { get; set; }

    public void UpdateLanguages()
    {
        var fileService = new FileService();
        var httpService = new HttpService(new HttpClient());
        var languageService = new LanguageService(fileService, httpService, FileName);

        Languages.Add(new Language { Name = "Python" });
        Languages.Add(new Language { Name = "Rust" });
        Languages.Add(new Language { Name = "Golang" });
        Languages.Add(new Language { Name = "C#" });
        Languages.Add(new Language { Name = "C++" });
        Languages.Add(new Language { Name = "Python" });
        Languages.Add(new Language { Name = "Rust" });
        Languages.Add(new Language { Name = "Golang" });
        Languages.Add(new Language { Name = "C#" });
        Languages.Add(new Language { Name = "C++" });
        Languages.Add(new Language { Name = "C++" });
        Languages.Add(new Language { Name = "C++" });
        // Uncomment when app is done
        // while (true){
        //     Thread.Sleep(5000);
        //     try
        //     {
        //         Languages = new List<Language>(
        //             await languageService.GetLanguages(
        //                 $"api/languages?platform={RuntimeInformationExtensions.PlatformName()}"
        //             )
        //         );
        //     }
        //     catch (Exception)
        //     {

        //     }
        // }
    }
}