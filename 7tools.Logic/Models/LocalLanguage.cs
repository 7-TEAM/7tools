namespace SvTools.Models;

public class LocalLanguage
{
    public float InstalledVersion { get; set; }
    public string DownloadPath { get; set; }
    public bool IsChecked { get; set; }
    public bool ShouldBeEnvironmentVariable { get; set; }
}