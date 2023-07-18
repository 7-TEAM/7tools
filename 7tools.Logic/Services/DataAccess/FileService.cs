using Newtonsoft.Json.Linq;

namespace SvTools.Services.DataAccess;

public class FileService : IFileService
{ 
    public async Task<string> ReadContentAsync(string fileName)
    {
        return await File.ReadAllTextAsync(fileName);
    }

    public JObject ReadJsonObject(string content)
    {
        return JObject.Parse(content);
    }

    public JArray ReadJsonArray(string content)
    {
        return JArray.Parse(content);
    }

    public async Task WriteAsync(string fileName, string content)
    {
        await File.WriteAllTextAsync(fileName, content);
    }

    public void UnpackLanguage(string path)
    {
        throw new NotImplementedException();
    }
}