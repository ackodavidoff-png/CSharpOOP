using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Interfaces
{
    public interface ILogger
    {
        //Info = 1,
        //Warning = 2,
        //Error = 3,
        //Critical = 4,
        //Fatal = 5
        void Info(string date, string message);
        void Warning(string date, string message);
        void Error(string date, string message);
        void Critical(string date, string message);
        void Fatal(string date, string message);
    }
}
