using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamProgres iStreamProgres;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamProgres file)
        {
            this.iStreamProgres = file;
        }

        public int CalculateCurrentPercent()
        {
            return (this.iStreamProgres.BytesSent * 100) / this.iStreamProgres.Length;
        }
    }
}
