using Newtonsoft.Json.Linq;

namespace SvTools.Services.DataAccess;

public interface IFileReader
{
    string ReadContent(string fileName);
    JObject ReadJsonObject(string content);
    JArray ReadJsonArray(string content);
}