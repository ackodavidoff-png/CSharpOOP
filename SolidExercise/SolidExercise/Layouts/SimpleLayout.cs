using SolidExercise.Enums;
using SolidExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format(string date, ReportLevel report, string message)
        {
            return $"{date} - {report} - {message}";
        }
    }
}
