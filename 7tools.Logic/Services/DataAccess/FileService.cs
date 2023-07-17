using Newtonsoft.Json.Linq;

namespace SvTools.Services.DataAccess;

public class FileService : IFileService
{
    public string ReadContent(string fileName)
    {
        return File.ReadAllText(fileName);
    }

    public JObject ReadJsonObject(string content)
    {
        return JObject.Parse(content);
    }

    public JArray ReadJsonArray(string content)
    {
        return JArray.Parse(content);
    }

    public void Write(string fileName, string content)
    {
        File.WriteAllText(fileName, content);
    }
}