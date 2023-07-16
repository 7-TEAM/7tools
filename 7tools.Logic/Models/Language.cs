namespace SvTools.Models;

public class Language
{
    public int Id { get; init; }
    public string Name { get; init; }
    public float CurrentVersion { get; init; }
    public string ImageUrl { get; init; }
    public string[] DownloadUrls { get; set; }
    public LocalLanguage LocalLanguage { get; set; } = new();
}