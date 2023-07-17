namespace SvTools.Models;

public class Language
{
    public int Id { get; init; }
    public string Name { get; init; }
    public Version CurrentVersion { get; init; } = new();
    public string ImageUrl { get; init; }
    public List<Version> Versions { get; set; } = new();
    public LocalLanguage LocalLanguage { get; set; } = new();
}