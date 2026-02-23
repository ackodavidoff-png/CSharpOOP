using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        public Box(double l, double w,  double h)
        {
            this.Length = l;
            this.Width = w;
            this.Height = h;
        }
        private double length;
        private double width;
        private double height;
        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Heigth cannot be zero or negative.");
                }
                this.height = value;
            }
        }
        public double SurfaceArea()
        {
            //Surface Area = 2lw + 2lh + 2wh
            double sufaceArea = (2 * (this.Length * this.Width)) + (2 * (this.Length * this.Height)) + (2 * (this.Width * this.Height));
            return sufaceArea;//this.width * this.height;
        }
        public double LateralSurfaceArea()
        {
            //Lateral Surface Area = 2lh + 2wh
            double lateralSurfaceArea = (2 * (this.Length * this.Height)) + (2 * (this.Width * this.Height));
            return lateralSurfaceArea;
        }
        public double Volume()
        {
            //Volume = lwh
            double volume = this.Length * this.Width * this.Height;
            return volume;
        }
    }
}
