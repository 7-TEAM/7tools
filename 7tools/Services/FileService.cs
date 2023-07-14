using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tools.Models;

namespace SvTools.Services;

public class FileService : IFileService
{
    private readonly string _fileName;

    public FileService(string fileName)
    {
        _fileName = $"{fileName}.json";
    }

    public void CreateFileIfNotExists()
    {
        File.Create(_fileName);
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