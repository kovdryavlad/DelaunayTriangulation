using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    public class PointZ
    {
        public double X { get; set; }
        public double Y { get; set; }

        
        public PointZ(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return String.Format("({0:0.00}; {1:0.00})", X, Y);
        }

        public static implicit operator System.Windows.Point(PointZ p) => new System.Windows.Point(p.X, p.Y);
    }
}
