using Newtonsoft.Json;
using Tools.Models;

namespace SvTools.Services;

public class SettingsService
{
    private readonly IFileService _file;    
    private readonly string _fileName;

    public SettingsService(IFileService file, string fileName)
    {
        _file = file;
        _fileName = fileName;
    }
    
    public Settings LoadSettings()
    {
        return JsonConvert.DeserializeObject<Settings>(_file.ReadContent(_fileName));
    }

    public void ChangeSettings(string field, string newValue)
    {
        
    }
}