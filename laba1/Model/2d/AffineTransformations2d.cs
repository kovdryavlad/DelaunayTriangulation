using SimpleMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1.Model._2d
{
    class AffineTransformationsMartix2d
    {
        public static Matrix RotateX(double fi)
        {
            fi = fi * Math.PI / 180d;
            Matrix matrixOfRotation = new Matrix(3, 3, new[] {
                 Math.Cos(fi),  Math.Sin(fi),  0,
                -Math.Sin(fi),  Math.Cos(fi),  0,
                            0,             0,  1
            });

            return matrixOfRotation;
        }

        public static Matrix Dilation(double a, double b)
        {
            Matrix matrixOfTransformation = new Matrix(3, 3, new[] {
               a, 0, 0,
               0, b, 0,
               0, 0, 1
           });

            return matrixOfTransformation;
        }

        public static Matrix Translation(double l, double m)
        {
            Matrix matrixOfTransformation = new Matrix(3, 3, new[] {
               1, 0, 0,
               0, 1, 0,
               l, m, 1
           });

            return matrixOfTransformation;
        }

        public static Matrix MirrorX()
        {
            Matrix matrixOfTransformation = new Matrix(3, 3, new[] {
               1, 0,  0,
               0, -1, 0,
               0, 0,  1.0,
           });

            return matrixOfTransformation;
        }

        public static Matrix MirrorY()
        {
            Matrix matrixOfTransformation = new Matrix(3, 3, new[] {
               -1, 0,   0, 
                0, 1,   0, 
                0, 0, 1.0 
           });

            return matrixOfTransformation;
        }
    }
}

