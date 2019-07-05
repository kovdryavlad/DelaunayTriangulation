using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class JarvisAlgorithm
    {
        private static double PseudoscolarMult(PointZ k, PointZ a, PointZ b)
        {
            return ((a.X - k.X) * (b.Y - k.Y) - (b.X - k.X) * (a.Y - k.Y));
        }

        private static void SwapPoints(ref PointZ a, ref PointZ b)
        {
            PointZ tmp = a;
            a = b;
            b = tmp;
        }

        public static List<PointZ> JarvisHull(PointZ[] points)
        {
            var Shell = new List<PointZ>();

            //Ищем отправную точку
            Int32 asStart = 0;
            for (int i = 1; i < points.Length; i++)
            {
                if (Math.Abs(points[i].Y - points[asStart].Y) < 0.000001)
                    if (points[i].X < points[asStart].X)
                        asStart = i;
                    else;
                else if (points[i].Y < points[asStart].Y)
                    asStart = i;

            }
            var startpoint = new PointZ(points[asStart].X, points[asStart].Y);

            Shell.Add(points[asStart]);

            PointZ current = points[asStart];
            SwapPoints(ref points[points.Length - 1], ref points[asStart]);
            Int32 k = 0;

            //Алгоритм выборки точек
            do
            {

                for (int i = k; i < points.Length; i++)
                    if (PseudoscolarMult(current, points[i], points[k]) < 0)
                        SwapPoints(ref points[k], ref points[i]);
                current = points[k];
                Shell.Add(points[k]);
                k++;
            }
            while (!IsEqualPoints(current, startpoint));

            //Shell.Add(startpoint);
            
            return new HashSet<PointZ>(Shell).ToList();
        }

        private static bool IsEqualPoints(PointZ current, PointZ startpoint)
        {
            return current.X == startpoint.X && current.Y == startpoint.Y;
        }
    }
}
