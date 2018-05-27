using System;
using System.Collections.Generic;
using System.Text;

public interface IAppender:ILevelable
{
    void Append(IError error);
    
    ILayout Layout {get; }
}