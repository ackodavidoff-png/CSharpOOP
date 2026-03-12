using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Interfaces
{
    public interface ILogFile
    {
        int Size {  get; }
        void Write(string message);
    }
}
