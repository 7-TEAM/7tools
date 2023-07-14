using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;
using System.Threading;
using System.Net.Http;
using SvTools.ViewModels;
using SvTools.Views;
using SvTools.Services;
using SvTools.Models;

namespace SvTools;

public partial class App : Application
{
    private Language[] _languages;
    public override void Initialize()
    {
        var thread = new Thread(new ThreadStart(UpdateLanguages));
        thread.Start();
        thread.Join();

        AvaloniaXamlLoader.Load(this);

    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private async void UpdateLanguages(){
        var client = new HttpClient();
        var httpService = new HttpService(client);
        var fileService = new FileService();
        var languageService = new LanguageService(fileService, httpService);

        fileService.CreateFileIfNotExists("");
        
        while (true){
            Thread.Sleep(5000);
            this._languages = await languageService.GetLanguages("","");
        }
    }
}