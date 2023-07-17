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

    public async Task DownloadLanguage(Language language)
    {
        await _http.DownloadFileAsync(language.LocalLanguage.Version.Url, language.LocalLanguage.DownloadPath);
    }
}