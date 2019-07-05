using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMatrix;

namespace laba1.Model._3d
{
    class AffineTransformationsMatrix3d
    {
        public static Matrix RotateX(double fi)
        {
            fi = fi * Math.PI / 180d; 
            Matrix matrixOfRotation = new Matrix(4, 4, new[] {
                1,              0,             0,  0,
                0,   Math.Cos(fi),  Math.Sin(fi),  0,
                0,  -Math.Sin(fi),  Math.Cos(fi),  0, 
                0,              0,             0,  1

            });

            return matrixOfRotation;
        }

        public static Matrix RotateY(double fi)
        {
            fi = fi * Math.PI / 180d;
            Matrix matrixOfRotation = new Matrix(4, 4, new[] {
                Math.Cos(fi),  0,  -Math.Sin(fi),  0,
                           0,  1,              0,  0,
                Math.Sin(fi),  0,   Math.Cos(fi),  0,
                           0,  0,              0,  1

            });

            return matrixOfRotation;
        }

        public static Matrix RotateZ(double fi)
        {
            fi = fi * Math.PI / 180d;
            Matrix matrixOfRotation = new Matrix(4, 4, new[] {
                Math.Cos(fi),  Math.Sin(fi),  0,  0,
               -Math.Sin(fi),  Math.Cos(fi),  0,  0,
                           0,             0,  1,  0,
                           0,             0,  0,  1

            });

            return matrixOfRotation;
        }

        public static Matrix Dilation(double a, double b, double c)
        {
           Matrix matrixOfTransformation = new Matrix(4, 4, new[] {
               a, 0, 0, 0,
               0, b, 0, 0,
               0, 0, c, 0,
               0, 0, 0, 1
           });

            return matrixOfTransformation;
        }

        public static Matrix Translation(double l, double m, double n)
        {
            Matrix matrixOfTransformation = new Matrix(4, 4, new[] {
               1, 0, 0, 0,
               0, 1, 0, 0,
               0, 0, 1, 0,
               l, m, n, 1
           });

            return matrixOfTransformation;
        }

        public static Matrix MirrorXY()
        {
            Matrix matrixOfTransformation = new Matrix(4, 4, new[] {
               1, 0,  0, 0,
               0, 1,  0, 0,
               0, 0, -1, 0,
               0, 0,  0, 1.0
           });

            return matrixOfTransformation;
        }

        public static Matrix MirrorYZ()
        {
            Matrix matrixOfTransformation = new Matrix(4, 4, new[] {
               -1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1.0
           });

            return matrixOfTransformation;
        }

        public static Matrix MirrorXZ()
        {
            Matrix matrixOfTransformation = new Matrix(4, 4, new[] {
                1,  0, 0, 0,
                0, -1, 0, 0,
                0,  0, 1, 0,
                0,  0, 0, 1.0
           });

            return matrixOfTransformation;
        }
    }
}
