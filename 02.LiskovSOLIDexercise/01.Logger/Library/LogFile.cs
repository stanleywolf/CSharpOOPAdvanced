using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class LogFile : ILogFile
{
    private const string DEFAULTPATH = "./data/";

    public LogFile(string fileName)
    {
        this.Path = DEFAULTPATH + fileName;
        InitializedFile();
        this.Size = 0;
    }

    private void InitializedFile()
    {
        Directory.CreateDirectory(DEFAULTPATH);
        File.AppendAllText(this.Path,"");
    }

    public int Size { get; private set; }
    public string Path { get; }

    public void WriteToFile(string errorLog)
    {
        File.AppendAllText(this.Path, errorLog + Environment.NewLine);

        int addedSize = 0;
        for (int i = 0; i < errorLog.Length; i++)
        {
            addedSize += errorLog[i];
        }
        this.Size += addedSize;
    }

}

