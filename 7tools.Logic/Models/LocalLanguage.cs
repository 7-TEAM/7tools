namespace SvTools.Models;

public class LocalLanguage
{
    public Version PickedVersion { get; set; } = new();
    public string DownloadPath { get; set; }
    public bool IsChecked { get; set; }
    public bool ShouldBeEnvironmentVariable { get; set; }
}