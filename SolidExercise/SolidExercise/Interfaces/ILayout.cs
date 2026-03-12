using SolidExercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Interfaces
{
    public interface ILayout
    {
        string Format(string date, ReportLevel level, string message);
    }
}
