using SolidExercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Interfaces
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }
        int MessagesAppended { get; }
        void Append(string date, ReportLevel level, string message);
    }
}
