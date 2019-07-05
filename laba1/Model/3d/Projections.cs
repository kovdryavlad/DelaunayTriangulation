using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMatrix;

namespace laba1.Model._3d
{
    class ProjectionsMatrix
    {
        public static Matrix GetPx()
        {
            Matrix px = new Matrix(4, 4, new[] {
                0, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1.0
            });

            return px;
        }

        public static Matrix GetPy()
        {
            Matrix py = new Matrix(4, 4, new[] {
                1, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1.0
            });

            return py;
        }

        public static Matrix GetPz()
        {
            Matrix pz = new Matrix(4, 4, new[] {
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 1.0
            });

            return pz;
        }

        public static Matrix GetIsometric()
        {
            Matrix isometric = new Matrix(4, 4, new[] {
                0.707, -0.408, 0, 0,
                    0,  0.816, 0, 0,
               -0.707, -0.408, 0, 0,
                    0,      0, 0, 1
            });

            return isometric;
        }

        public static Matrix GetPKavalie()
        {
            double alpha = 45;
            double l = 1;
            alpha = alpha * Math.PI / 180d;
            Matrix projection = new Matrix(4, 4, new[] {
                                1,                 0, 0, 0,
                                0,                 1, 0, 0,
                l*Math.Cos(alpha), l*Math.Sin(alpha), 1, 0,
                                0,                 0, 0, 1.0
            });

            return projection;
        }

        public static Matrix GetPerspective3point(double a, double b, double c)
        {
            Matrix projection = new Matrix(4, 4, new[] {
                1, 0, 0, -1/a,
                0, 1, 0, -1/b,
                0, 0, 1, -1/c,
                0, 0, 0,  1.0
            });

            return projection;
        }
    } 
}
