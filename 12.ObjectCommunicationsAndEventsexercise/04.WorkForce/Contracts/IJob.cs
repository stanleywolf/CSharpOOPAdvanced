using System;
using System.Collections.Generic;
using System.Text;

public interface IJob:INameble
{
    event JobDoneEventHandler JobDone;

    int RequiredHoursOfWork { get; }

    void Update();
}