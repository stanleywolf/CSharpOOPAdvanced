using System;
using System.Collections.Generic;
using System.Text;

public class JobEventArgs:EventArgs
{
    private Job job;

    public JobEventArgs(IJob job)
    {
        this.Job = job;
    }

    

    public IJob Job { get; }
}