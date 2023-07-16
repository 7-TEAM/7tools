namespace SvTools.Services.DataAccess;

public interface IFileWriter
{
    bool CreateFileIfNotExists(string fileName);
    void Write(string fileName, string content);
}