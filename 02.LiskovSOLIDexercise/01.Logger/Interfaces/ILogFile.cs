using System;
using System.Collections.Generic;
using System.Text;

public interface ILogFile
{
    int Size { get; }

    void WriteToFile(string errorLog);

    string Path { get; }
}
