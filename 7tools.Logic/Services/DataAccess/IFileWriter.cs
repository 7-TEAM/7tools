namespace SvTools.Services.DataAccess;

public interface IFileWriter
{
    void Write(string fileName, string content);
}