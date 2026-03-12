using SolidExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Files
{
    public class LogFile : ILogFile
    {
        private StringBuilder sb = new StringBuilder();
        public int Size
        {
            get
            {
                int sum = 0;
                foreach (char symbol in sb.ToString())
                {
                    if (char.IsLetter(symbol))
                    {
                        sum += (int)symbol;
                    }
                }
                return sum;
            }
        }
        public void Write(string text)
        {
            sb.AppendLine(text); 
        }
    }
}
