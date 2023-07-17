using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using SvTools.Models;
using SvTools.Models.Extensions;
using SvTools.Services;
using SvTools.Services.DataAccess;
using SvTools.Services.WebAccess;
using Timer = System.Timers.Timer;

namespace SvTools.View.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public List<Language> Languages {get; set;}

    public bool IsDownloadingButtonPressed {get; set;}

    private const string FileName = "config.json";
    private readonly LanguageService _languageService;
    private readonly DownloadService _downloadService;

    public MainWindowViewModel()
    {
        Languages = new List<Language>();
        var fileService = new FileService();
        var httpService = new HttpService(new HttpClient());
        _languageService = new LanguageService(fileService, httpService, FileName);
        _downloadService = new DownloadService(httpService);
        UpdateLanguages();
    }

    private void UpdateLanguages()
    {
        var timer = new Timer(5000);
        async Task UpdateTimerAsync()
        {
            try
            {
                Languages = new List<Language>(
                    await _languageService.GetLanguagesAsync(
                        $"api/languages?platform={RuntimeInformationExtensions.PlatformName()}"
                    )
                );
            }
            catch (Exception)
            {

            }
             
        }
        timer.Elapsed += (_, _) => UpdateTimerAsync().GetAwaiter().GetResult();
        timer.Enabled = true;
    }
}