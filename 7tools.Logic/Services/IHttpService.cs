namespace SvTools.Services;

public interface IHttpService
{
    Task<string> SendRequest(string endpoint);
    Task<string> SendGet(string endpoint);
    Task<string> SendPost(string endpoint);
}