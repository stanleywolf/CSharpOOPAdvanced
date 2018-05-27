using System;
using System.Collections.Generic;
using System.Text;

public interface IHendler
{
    void Handle(LogType logType, string massage);
    void SetSuccessor(IHendler handler);
}