using SolidExercise.Enums;
using SolidExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private readonly ILayout layout;
        //private readonly ILogFile file;
        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout; 
            this.ReportLevel = ReportLevel.Info;
        }
        public ReportLevel ReportLevel { get; set; }
        public int MessagesAppended { get; private set; }
        public void Append(string date, ReportLevel level, string message)
        {
            if(level < ReportLevel)
            {
                return;
            }
            string formatted = layout.Format(date, level, message);
            Console.WriteLine(formatted);
            MessagesAppended++;
        }
        public override string ToString()
        {
            return $"Appender type: ConsoleAppender, Layout type: {layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppended}";
        }
    }
}
