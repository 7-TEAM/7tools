using System.Collections.Generic;
using System.Net.Http;
using System;

using System.ComponentModel;
using System.Runtime.CompilerServices; 
using System.Threading.Tasks;
using Avalonia.Styling;
using Avalonia.Threading;
using MsBox.Avalonia;
using MsBox.Avalonia.Base;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using SvTools.Models;
using SvTools.Models.Extensions;
using SvTools.Services;
using SvTools.Services.DataAccess;
using SvTools.Services.WebAccess;
using Icon = System.Drawing.Icon;
using Timer = System.Timers.Timer;

namespace SvTools.View.ViewModels;

public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    public List<Language> Languages {get; set;}

    public bool IsDownloadingButtonPressed {get; set;}

    private const string FileName = "config.json";
    private readonly LanguageService _languageService;
    private readonly DownloadService _downloadService;
    private readonly DispatcherTimer _disTimer;
    

    public event PropertyChangedEventHandler PropertyChanged; 

    public MainWindowViewModel()
    {
        Languages = new List<Language>();
        var fileService = new FileService();
        var httpService = new HttpService(new HttpClient());
        _languageService = new LanguageService(fileService, httpService, FileName);
        _downloadService = new DownloadService(httpService);
        _disTimer = new DispatcherTimer();
        UpdateLanguages();
    }
    
    private void UpdateLanguages()
    {
        UpdateTimerAsync(null, null);
        _disTimer.Interval = TimeSpan.FromHours(3);
        _disTimer.Tick += UpdateTimerAsync;
        _disTimer.Start();
    }

    private async void UpdateTimerAsync(object? sender, EventArgs e)
    {
        try
        {
            var copyOfLanguages = Languages;
            Languages = new List<Language>(
                await _languageService.GetLanguagesAsync(
                    $"api/languages?platform={RuntimeInformationExtensions.PlatformName()}"
                )
            );
            await UpdateLanguages(
                _languageService.GetLanguagesToUpdate(copyOfLanguages.ToArray(), Languages.ToArray()));
            NotifyPropertyChanged(nameof(Languages));
        }
        catch (Exception)
        {
            var messageBox = MessageBoxManager
                .GetMessageBoxStandard("Błąd", "Nie udało się pobrać języków.");
            await messageBox.ShowAsync();
        }
    }

    private async Task UpdateLanguages(Language[] languagesToUpdate)
    {
        foreach (var language in languagesToUpdate)
        {
            await _downloadService.DownloadLanguageAsync(language);
            await _languageService.UpdateLocalLanguageAsync(language, language.LocalLanguage);
        }
    }

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")  
    {  
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }  
}