using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Core.IO.Contracts
{
    class ConsoleReader:IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
