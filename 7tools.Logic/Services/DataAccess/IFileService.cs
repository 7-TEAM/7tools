namespace SvTools.Services.DataAccess;

public interface IFileService : IFileReader, IFileWriter
{
    void UnpackLanguage(string path);
}