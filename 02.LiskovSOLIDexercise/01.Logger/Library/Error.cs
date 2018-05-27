using System;
using System.Collections.Generic;
using System.Text;

public class Error:IError
    {
        public ErrorLevel Level { get; }
        public DateTime DateTime { get; }
        public string Message { get; }

        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }
    }
  