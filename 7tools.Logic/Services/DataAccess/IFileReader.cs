using Newtonsoft.Json.Linq;

namespace SvTools.Services.DataAccess;

public interface IFileReader
{
    Task<string> ReadContentAsync(string fileName);
    JObject ReadJsonObject(string content);
    JArray ReadJsonArray(string content);
}