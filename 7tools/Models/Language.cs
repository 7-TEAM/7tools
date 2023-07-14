namespace Tools.Models;

public class Language
{
    public required string Name { get; init; }
    public required float InstalledVersion { get; init; }
    public required float CurrentVersion { get; init; }
    public required string PathToImage { get; init; }
    public required string UrlToApi { get; init; }
    public string DownloadPath { get; set; }
    public bool IsChecked { get; set; }
    public bool ShouldBeEnvironmentVariable { get; set; }
    
}