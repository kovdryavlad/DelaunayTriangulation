using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using  SimpleMatrix;

namespace laba1.Model
{
    internal class Triangulation
    {
        class CenterRadiusObject
        {
            public PointZ center;
            public double radius;
        }

        static Func<PointZ, PointZ, PointZ> pointsDifference = (a, b) => new PointZ(a.X - b.X, a.Y - b.Y);

        static Func<PointZ, double> getDistanceOfVector = p => Math.Sqrt(p.X * p.X + p.Y * p.Y);

        static Func<PointZ, PointZ, double> getpointsDistance = (p1, p2) => getDistanceOfVector(pointsDifference(p1, p2));

        internal static Triangle[] Process(List<PointZ> points, bool flag, int steps)
        {
            List<PointZ> sortedPoints = points.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
            PointZ x_0 = sortedPoints[0];

            List<PointZ> otherPoints = sortedPoints.Skip(1).OrderBy(x_i => getpointsDistance(x_0, x_i)).ToList();
            PointZ x_j = otherPoints[0];

            //skip x_j element
            otherPoints = otherPoints.Skip(1).ToList();

            var centerRadiusCollection = otherPoints.Select((p, index) =>
            {
                CenterRadiusObject crObject;

                try
                {
                    crObject = getCenterAndRadiusCircle(x_0, x_j, p);
                }
                catch
                {
                    double epsilon = 0.1;
                    crObject = getCenterAndRadiusCircle(x_0, x_j, new PointZ(p.X + epsilon, p.Y));
                }

                return new { Point = p, Index = index, Radius = crObject.radius, Center = crObject.center };

            }).ToList();

            double minRadius = centerRadiusCollection.Min(el => el.Radius);
            var minRadiusElement = centerRadiusCollection.Find(el => el.Radius == minRadius);
            PointZ c = minRadiusElement.Center;

            PointZ x_k = minRadiusElement.Point;
            centerRadiusCollection.RemoveAt(minRadiusElement.Index);

            List<PointZ> pointsSi = centerRadiusCollection
                                     .Select(el => el.Point)
                                     .OrderBy(el => getpointsDistance(el, c))
                                     .ToList();

            List<Triangle> result = new List<Triangle>();


            List<PointZ> pointsInTringulation = new List<PointZ>();
            pointsInTringulation.Add(x_0);
            pointsInTringulation.Add(x_j);
            pointsInTringulation.Add(x_k);

            //List<PointZ> pointsInTringulationPrev = pointsInTringulation.Select(el => el).ToList();
            List<PointZ> PrevConvexHull = pointsInTringulation.Select(el => el).ToList().ToList();


            result.Add(new Triangle(x_0, x_j, x_k));

            //return result.ToArray();

            bool debugFlag = false;

            for (int i = 0; i < pointsSi.Count; i++)
            {
               

                var currentPoint = pointsSi[i];

                pointsInTringulation.Add(currentPoint);
                var convexHull = JarvisAlgorithm.JarvisHull(pointsInTringulation.ToArray());

                //разность множеств
                List<PointZ> difference = PrevConvexHull.Except(convexHull).ToList();

                if (difference.Count == 0)
                {
                    //рисуем один треугольник

                    var nearestPointsOfConvexHull = getTwoNearestConvexHullPoints(convexHull, currentPoint);
                    var trianglewithNearestPointsOfHull = new Triangle(currentPoint, nearestPointsOfConvexHull[0], nearestPointsOfConvexHull[1]);
                    
                    var adjacentTriangle = result.Find(triangle => triangle.Contains(nearestPointsOfConvexHull[0]) && triangle.Contains(nearestPointsOfConvexHull[1]));

                    result.Add(trianglewithNearestPointsOfHull);

                    if (adjacentTriangle != null)
                        fixTriangles(result, trianglewithNearestPointsOfHull, adjacentTriangle);
                }
                

                else  //когда разность множеств больше 1
                {
                    PointZ[] nearest = getTwoNearestConvexHullPoints(convexHull, currentPoint);

                    if (IsUnderTheLine(nearest[0], nearest[1], currentPoint))
                    {
                        //swapPoints
                        PointZ third = nearest[0];

                        nearest[0] = nearest[1];
                        nearest[1] = third;

                        difference = difference.OrderByDescending(p => p.X).ToList();
                    }

                    //difference = difference.OrderBy(p => p.X).ToList();

                    var t1 = new Triangle(currentPoint, nearest[0], difference[0]);
                    var neighbour1 = result.Find(t => t.Contains(nearest[0]) && t.Contains(difference[0]));
                    
                    result.Add(t1);
                    if (neighbour1 != null)
                        fixTriangles(result, t1, neighbour1);

                    for (int j = 0; j < difference.Count - 1; j++)
                    {
                        var ti = new Triangle(currentPoint, difference[j], difference[j + 1]);
                        var neighbouri = result.Find(t => t.Contains(difference[j]) && t.Contains(difference[j + 1]));

                        result.Add(ti);
                        if (neighbouri != null)
                            fixTriangles(result, ti, neighbouri);
                    }

                    var t2 = new Triangle(currentPoint, nearest[1], difference[difference.Count - 1]);
                    var neighbour2 = result.Find(t => t.Contains(nearest[1]) && t.Contains(difference[difference.Count - 1]));

                    result.Add(t2);
                    if (neighbour2 != null)
                        fixTriangles(result, t2, neighbour2);

                }

                //pointsInTringulationPrev.Add(currentPoint);
                PrevConvexHull = convexHull;

                if (debugFlag)
                    return result.ToArray();

                if (steps == i)
                    return result.ToArray();
            }

            System.Diagnostics.Debug.WriteLine("triangles.count = " + result.Count);
            return result.ToArray();
        }

        private static void fixTriangles(List<Triangle> result, Triangle triangleA, Triangle triangleB)
        {
            var union = triangleA.vertexes.Union(triangleB.vertexes).ToArray();
            if (union.Length < 4)
                return;

            if (!isConvex(union))
                return;

            var existingDiagonal = triangleA.vertexes.Intersect(triangleB.vertexes).ToArray();
            var alternativeDiagonal = new []{ triangleA.vertexes.Except(existingDiagonal).ToArray()[0],  triangleB.vertexes.Except(existingDiagonal).ToArray()[0] };

            if (getpointsDistance(existingDiagonal[0], existingDiagonal[1]) < getpointsDistance(alternativeDiagonal[0], alternativeDiagonal[1]))
                return;

            //перестраивание
            result.Remove(triangleA);
            result.Remove(triangleB);

            
            var alternativeTriangleA = new Triangle(alternativeDiagonal[0], alternativeDiagonal[1], existingDiagonal[0]);
            var alternativeTriangleB = new Triangle(alternativeDiagonal[0], alternativeDiagonal[1], existingDiagonal[1]);

            //тут кастыль

            var fourthPoint = triangleB.vertexes.Except(existingDiagonal).ToArray()[0];

            var adjacentTriangleA = result.Where(t => t.Contains(fourthPoint) && t.Contains(existingDiagonal[0])).ToArray();
            var adjacentTriangleB = result.Where(t => t.Contains(fourthPoint) && t.Contains(existingDiagonal[1])).ToArray();


            result.Add(alternativeTriangleA);
            result.Add(alternativeTriangleB);

            

            
            if (adjacentTriangleA.Length > 0)
                fixTriangles(result, alternativeTriangleA, adjacentTriangleA[0]);

            if (adjacentTriangleB.Length > 0)
                fixTriangles(result, alternativeTriangleB, adjacentTriangleB[0]);

        }

        private static bool isConvex(PointZ[] union)
        {
            var convexHull = JarvisAlgorithm.JarvisHull(union);

            if (convexHull.Count== 4)
                return true;

            return false;
        }

        static bool IsUnderTheLine(PointZ A, PointZ B, PointZ P)
        {
            double x = P.X;
            double y = P.Y;

            double x1 = A.X;
            double y1 = A.Y;

            double x2 = B.X;
            double y2 = B.Y;

            double f = (y1 - y2) * x + (x2 - x1) * y + (x1 * y2 - x2 * y1);
            return f < 0;
        }

        static PointZ[] getTwoNearestConvexHullPoints(List<PointZ> convexHull, PointZ p) {

            PointZ[] result = new PointZ[2];

            var index = convexHull.FindIndex(el => el == p);
            var convexHullLast = convexHull.Count - 1;


            if (index == 0)
            {
                result[0] = convexHull[1];
                result[1] = convexHull[convexHullLast];
            }

            else if (index == convexHullLast)
            {
                result[0] = convexHull[convexHullLast - 1];
                result[1] = convexHull[0];
            }

            else
            {
                result[0] = convexHull[index - 1];
                result[1] = convexHull[index + 1];
            }

            return result;
        }

      

        static CenterRadiusObject getCenterAndRadiusCircle(PointZ a, PointZ b, PointZ c)
        {
            Matrix d = new Matrix(3, 3, new[] {
                a.X, a.Y, 1.0,
                b.X, b.Y, 1.0,
                c.X, c.Y, 1.0
            });

            Matrix x0Matrix = new Matrix(3, 3, new[] {
                a.X*a.X + a.Y*a.Y, a.Y, 1.0,
                b.X*b.X + b.Y*b.Y, b.Y, 1.0,
                c.X*c.X + c.Y*c.Y, c.Y, 1.0
            });

            Matrix y0Matrix = new Matrix(3, 3, new[] {
                a.X*a.X + a.Y*a.Y, a.X, 1.0,
                b.X*b.X + b.Y*b.Y, b.X, 1.0,
                c.X*c.X + c.Y*c.Y, c.X, 1.0
            });

            double D = 2 * d.Determinant();

            PointZ center = new PointZ(x0Matrix.Determinant() / D, -y0Matrix.Determinant() / D);

            return new CenterRadiusObject() { center = center, radius = getpointsDistance(a, center) };
        }
    }
}
 