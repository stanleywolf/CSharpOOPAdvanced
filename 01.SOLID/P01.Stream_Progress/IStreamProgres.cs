using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public interface IStreamProgres
    {
        int BytesSent { get; }
        int Length { get; }
    }
}
