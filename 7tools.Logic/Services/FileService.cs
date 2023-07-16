using Newtonsoft.Json.Linq;

namespace SvTools.Services;

public class FileService : IFileService
{

    public void CreateFileIfNotExists(string fileName)
    {
        File.Create(fileName);
    }

    public string ReadContent(string fileName)
    {
        return File.ReadAllText(fileName);
    }

    public JObject ReadJson(string content)
    {
        return JObject.Parse(content);
    }
}