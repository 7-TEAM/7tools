namespace SvTools.Models;

public class LocalLanguageSettings
{
    public float InstalledVersion { get; set; }
    public string DownloadPath { get; set; }
    public bool IsChecked { get; set; }
    public bool ShouldBeEnvironmentVariable { get; set; }
}