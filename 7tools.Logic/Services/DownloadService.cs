using SvTools.Models;
using SvTools.Services.WebAccess;

namespace SvTools.Services;

public class DownloadService
{
    private readonly IHttpService _http;

    public DownloadService(IHttpService http)
    {
        _http = http;
    }

    public async Task DownloadLanguageAsync(Language language)
    {
        var localLanguage = language.LocalLanguage;
        await _http.DownloadFileAsync(localLanguage.PickedVersion.Url, localLanguage.DownloadPath);
    }
}