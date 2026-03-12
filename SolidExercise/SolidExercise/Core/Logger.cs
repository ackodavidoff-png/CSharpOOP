using SolidExercise.Enums;
using SolidExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Core
{
    public class Logger : ILogger
    {
        private readonly List<IAppender> appenders;
        public Logger(params IAppender[] appenders)//List<IAppender> appenders)
        {
            this.appenders = new List<IAppender>(appenders);
        }

        public void Critical(string date, string message)
        {
            Log(date, ReportLevel.Critical, message);
        }

        public void Error(string date, string message)
        {
            Log(date, ReportLevel.Error, message);
        }

        public void Fatal(string date, string message)
        {
            Log(date, ReportLevel.Fatal, message);
        }

        public void Info(string date, string message)
        {
            Log(date, ReportLevel.Info, message);
        }

        public void Log(string date, ReportLevel level, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(date, level, message);
            }
        }

        public void Warning(string date, string message)
        {
            Log(date, ReportLevel.Warning, message);
        }
        //public void ILogger.Info(string date, ReportLevel level, string message) => Log(date, ReportLevel.Info, message);
        //public void ILogger.Warning(string date, ReportLevel level, string message) => Log(date, ReportLevel.Warning, message);
        //public void ILogger.Error(string date, ReportLevel level, string message) => Log(date, ReportLevel.Error, message);
        //public void ILogger.Critical(string date, ReportLevel level, string message) => Log(date, ReportLevel.Critical, message);
        //public void ILogger.Fatal(string date, ReportLevel level, string message) => Log(date, ReportLevel.Fatal, message);

    }
}
