using System;
using System.Collections.Generic;
using System.Text;


public interface IError:ILevelable
{
    DateTime DateTime { get; }

    string Message { get; }
}