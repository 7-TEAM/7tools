namespace Tools.Models;

public class Language
{
    public required string Name { get; init; }
    public required float InstalledVersion { get; init; }
    public required float CurrentVersion { get; init; }
    public required string ImageUrl { get; init; }
    public required string[] DownloadUrls { get; set; }
    public string DownloadPath { get; set; }
    public bool IsChecked { get; set; }
    public bool ShouldBeEnvironmentVariable { get; set; }
    
}