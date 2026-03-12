using SolidExercise.Enums;
using SolidExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format(string date, ReportLevel level, string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine(@$"    <date>{date}</date>");
            sb.AppendLine($@"    <level>{level}</level>");
            sb.AppendLine($@"    <message>{message}</message>");
            sb.AppendLine(@"</log>");
            string sbAsString = sb.ToString();
            return sbAsString;
        }
    }
}
