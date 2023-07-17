﻿namespace SvTools.Services.WebAccess;

public interface IHttpService
{
    Task<string> SendGet(string endpoint);
    Task<string> SendPost(string endpoint);
    Task DownloadFileAsync(string url, string path);
}