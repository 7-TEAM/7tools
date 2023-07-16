using Newtonsoft.Json.Linq;

namespace SvTools.Services.DataAccess;

public class FileService : IFileService
{
    public bool CreateFileIfNotExists(string fileName)
    {
        if (File.Exists(fileName)) return false;
        File.Create(fileName);
        return true;

    }

    public string ReadContent(string fileName)
    {
        return File.ReadAllText(fileName);
    }

    public JObject ReadJson(string content)
    {
        return JObject.Parse(content);
    }

    public void Write(string fileName, string content)
    {
        File.WriteAllText(fileName, content);
    }
}