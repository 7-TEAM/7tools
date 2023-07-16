using Newtonsoft.Json.Linq;

namespace SvTools.Services.DataAccess;

public interface IFileReader
{
    string ReadContent(string fileName);
    JObject ReadJson(string content);
}