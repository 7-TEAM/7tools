﻿namespace SvTools.Services;

public interface IFileWriter
{
    void CreateFileIfNotExists(string fileName);
}