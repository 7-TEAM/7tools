using System.Runtime.InteropServices;

namespace Tools.Models.Extensions;

public static class RuntimeInformationExtensions
{
    public static string PlatformName()
    {
        string platform = null;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            platform = "linux";
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            platform = "windows";
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) platform = "macos";
        if (platform == null)
        {
            throw new NullReferenceException("Incorrect platform detected!");
        }
        return platform;
        
    }
}