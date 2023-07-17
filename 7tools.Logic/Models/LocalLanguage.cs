namespace SvTools.Models;

public class LocalLanguage
{
    public string InstalledVersion { get; set; }
    public string DownloadPath { get; set; }
    public bool IsChecked { get; set; }
    public bool ShouldBeEnvironmentVariable { get; set; }
}