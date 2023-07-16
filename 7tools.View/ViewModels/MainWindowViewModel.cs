using System.Collections.Generic;
using System.Threading;
using System.Net.Http;
using System;

using SvTools.Models;
using SvTools.Services;
using SvTools.Models.Extensions;

namespace SvTools.View.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public List<Language> Languages {get; set;}

    public MainWindowViewModel(){
        Languages = new List<Language>();

        new Thread(new ThreadStart(UpdateLanguages)).Start();
    }   

    public async void UpdateLanguages(){
        const string fileName = "config.json";
        var fileService = new FileService();
        var httpService = new HttpService(new HttpClient());
        var languageService = new LanguageService(fileService, httpService, fileName);

        Languages.Add(new Language{Name="Python"});
        Languages.Add(new Language{Name="Rust"});
        Languages.Add(new Language{Name="Golang"});
        Languages.Add(new Language{Name="C#"});
        Languages.Add(new Language{Name="C++"});
        Languages.Add(new Language{Name="Python"});
        Languages.Add(new Language{Name="Rust"});
        Languages.Add(new Language{Name="Golang"});
        Languages.Add(new Language{Name="C#"});
        Languages.Add(new Language{Name="C++"});
        Languages.Add(new Language{Name="C++"});
        Languages.Add(new Language{Name="C++"});
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