using Newtonsoft.Json.Linq;

namespace SvTools.Services;

public interface IFileService : IFileReader, IFileWriter
{
    JObject ReadJson(string content);
}