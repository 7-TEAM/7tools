namespace SvTools.Services.DataAccess;

public interface IFileWriter
{
    Task WriteAsync(string fileName, string content);
}