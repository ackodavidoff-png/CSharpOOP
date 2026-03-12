using SolidExercise.Enums;
using SolidExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Appenders
{
    public class FileAppender : IAppender
    {
        private readonly ILayout layout;
        private readonly ILogFile file;
        public FileAppender(ILayout layout, ILogFile file)
        {
            this.layout = layout;
            this.file = file;
            ReportLevel = ReportLevel.Info;
        }
        public ReportLevel ReportLevel { get; set; }
        public int MessagesAppended { get; private set; }
        public void Append(string date, ReportLevel level, string message)
        {
            if(level < this.ReportLevel)
            {
                return;
            }
            string formatted = layout.Format(date, level, message);
            file.Write(formatted);
            this.MessagesAppended++;
        }
        public override string ToString()
        {
            return $"Appender type: FileAppender, Layout type: {layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppended}, File size: {file.Size}";
        }
    }
}
