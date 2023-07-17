using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System;
using SvTools.Models;
using SvTools.Services;
using SvTools.Services.DataAccess;
using SvTools.Services.WebAccess;
using SvTools.Models.Extensions;

namespace SvTools.View.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public List<Language> Languages {get; set;}
    public List<LanguageButton> LanguageButtons {get; set;}

    public bool IsDownloadingButtonPressed {get; set;}

    private const string FileName = "config.json";

    public MainWindowViewModel()
    {
        Languages = new List<Language>();
        LanguageButtons = new List<LanguageButton>();

        new Thread(UpdateLanguages).Start();
    }

    public async void UpdateLanguages()
    {
        var fileService = new FileService();
        var httpService = new HttpService(new HttpClient());
        var languageService = new LanguageService(fileService, httpService, FileName);
        
        while (true){
            Thread.Sleep(5000);
            try
            {
                Languages = new List<Language>(
                    await languageService.GetLanguagesAsync(
                        $"api/languages?platform={RuntimeInformationExtensions.PlatformName()}"
                    )
                );

                Languages.ForEach((element) => LanguageButtons.Add(new LanguageButton(element)));
            }
            catch (Exception)
            {

            }
        }
    }

    private void Download(){

    }
}