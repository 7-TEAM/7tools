﻿namespace SvTools.Models;

public class Language
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required float CurrentVersion { get; init; }
    public required string ImageUrl { get; init; }
    public required string[] DownloadUrls { get; set; }
    public float InstalledVersion { get; set; }
    public string DownloadPath { get; set; }
    public bool IsChecked { get; set; }
    public bool ShouldBeEnvironmentVariable { get; set; }
    public Bit Bit { get; set; }
    
}