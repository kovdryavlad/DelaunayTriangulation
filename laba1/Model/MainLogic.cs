using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laba1.Model;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using SimpleMatrix;
using laba1.Model._3d;
using laba1.Model._2d;

namespace laba1.Model
{
    public class MainLogic : ReuseableThings.Model
    {
        CanvasPainter painter;
        Canvas m_paintDesk;
        public double Width { get => m_paintDesk.ActualWidth; }
        public double Height { get => m_paintDesk.ActualHeight; }

        //private List<PointZ> Points = new List<PointZ>();


        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(10 ,200),
        //    new PointZ(10 ,400),
        //    new PointZ(100,300),
        //    new PointZ(10 ,600)
        //});

        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(167,374),
        //    new PointZ(505,840),
        //    new PointZ(890,696),
        //    new PointZ(546,806)
        //});

        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(135,370),
        //    new PointZ(734,678),
        //    new PointZ(241,806),
        //    new PointZ(853,293),
        //    new PointZ(599,465),
        //    new PointZ(756,752),
        //    new PointZ(569,691)
        //});

        //офигеть пример
        private List<PointZ> Points = new List<PointZ>(new[] {
            new PointZ(409,293),
            new PointZ(73,301),
            new PointZ(352,173),
            new PointZ(228,402),
            new PointZ(569,139),
            new PointZ(181,204),
            new PointZ(563,390),
            new PointZ(383,459)
        });

        //мой любимый пример
        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(320,567),
        //    new PointZ(537,775),
        //    new PointZ(834,613),
        //    new PointZ(813,247),
        //    new PointZ(368,197),
        //    new PointZ(180,265),
        //    new PointZ(152,592),
        //    new PointZ(262,770),
        //    new PointZ(457,864),
        //    new PointZ(711,820),
        //    new PointZ(940,756)
        //});

        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(942,776),
        //    new PointZ(514,418),
        //    new PointZ(807,513),
        //    new PointZ(52,173),
        //    new PointZ(945,344),
        //    new PointZ(767,793),
        //    new PointZ(643,651),
        //    new PointZ(356,893),
        //    new PointZ(824,779),
        //    new PointZ(543,664)
        //});

        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(372,723),
        //    new PointZ(628,788),
        //    new PointZ(647,500),
        //    new PointZ(443,343),
        //    new PointZ(431,185),
        //    new PointZ(737,227),
        //    new PointZ(866,422),
        //    new PointZ(971,898),
        //    new PointZ(105,840)
        //});

        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(534,733),
        //    new PointZ(972,143),
        //    new PointZ(719,148),
        //    new PointZ(55,151),
        //    new PointZ(191,334),
        //    new PointZ(738,897),
        //    new PointZ(546,651),
        //    new PointZ(11,682),
        //    new PointZ(626,163),
        //    new PointZ(788,230)
        //});


        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(885,89),
        //    new PointZ(98,668),
        //    new PointZ(770,443),
        //    new PointZ(301,306),
        //    new PointZ(807,719),
        //    new PointZ(710,321)
        //});

        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(987,761),
        //    new PointZ(159,664),
        //    new PointZ(140,258),
        //    new PointZ(53,43),
        //    new PointZ(635,649)
        //});

        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(266,59),
        //    new PointZ(547,632),
        //    new PointZ(919,669),
        //    new PointZ(589,540),
        //    new PointZ(169,416)
        //});


        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(651,839),
        //    new PointZ(247,556),
        //    new PointZ(94,498),
        //    new PointZ(314,538),
        //    new PointZ(125,726)
        //});

        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(958,350),
        //    new PointZ(197,845),
        //    new PointZ(366,541),
        //    new PointZ(728,249),
        //    new PointZ(603,138)
        //});

        //private List<PointZ> Points = new List<PointZ>(new[] {
        //    new PointZ(100,100),
        //    new PointZ(100,130),
        //    new PointZ(110,110),
        //    new PointZ(131,130),
        //    new PointZ(140,100),
        //    new PointZ(140,120)
        //});

        public void GeneratePoints(int number)
        {
            var generator = new PointGenerator(1000,900);

            Points =  generator.Generate(number);
        }

        public void test()
        {
            painter.DrawPoint(new Point(10,10));
            painter.DrawLine(new Point(20,20), new Point(30, 30));

        }

        private void paintDesk_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(m_paintDesk);
            double x = pos.X;
            double y = m_paintDesk.ActualHeight - pos.Y;

            Points.Add(new PointZ(x, y));
            
            RepaintDesk();
        }

        internal void DoSteps(int steps)
        {
            var pntsCopy = Points.Select(p => p).ToList();
            clear2dPaintDesk();
            Points = pntsCopy;

            var triangles = Triangulation.Process(Points, testFlag, steps);

            for (int i = 0; i < triangles.Length; i++)
                DrawTriangle(triangles[i]);


            if (Points.Count > 0)
            {
                for (int i = 0; i < Points.Count; i++)
                    painter.DrawPoint(Points[i], System.Windows.Media.Brushes.Black);
            }
        }

        internal void clear2dPaintDesk()
        {
            Points.Clear();
            RepaintDesk();
        }

        public double ConvertToRadian(double fi)
        {
            return fi * 180d / Math.PI;
        }

        public void SetPaintDesk(Canvas canvas)
        {
            m_paintDesk = canvas;
            painter = new CanvasPainter(canvas);

            m_paintDesk.MouseDown += paintDesk_MouseDown;
        }

        
        
        
        private void RepaintDesk()
        {
            painter.ClearDesk();
            
            drawFigure();
        }

        internal void SavePoints()
        {
            string[] s = Points.Select(p => p.X + "\t" + p.Y).ToArray();
            File.WriteAllLines("points"+ DateTimeOffset.UtcNow.ToUnixTimeSeconds() + ".txt", s);
            
        }

        public void drawFigure()
        {
            if(Points.Count<3)
                return;

            var triangles = Triangulation.Process(Points, testFlag,-1);
            
            for (int i = 0; i < triangles.Length; i++)
                DrawTriangle(triangles[i]);
            

            if (Points.Count> 0)
            {
                for (int i = 0; i < Points.Count; i++)
                    painter.DrawPoint(Points[i], System.Windows.Media.Brushes.Black);
            }

            /*
            if (Points.Count > 3)
            {
                var converHull = JarvisAlgorithm.JarvisHull(Points.ToArray());

                for (int i = 1; i < converHull.Count; i++)
                    painter.DrawLine(converHull[i - 1], converHull[i], System.Windows.Media.Brushes.Blue);

                painter.DrawLine(converHull[0], converHull[converHull.Count-1], System.Windows.Media.Brushes.Blue);
            }
            */
        }

        private void DrawTriangle(Triangle triangle)
        {
            painter.DrawLine(triangle.vertexes[0], triangle.vertexes[1], System.Windows.Media.Brushes.Green);
            painter.DrawLine(triangle.vertexes[1], triangle.vertexes[2], System.Windows.Media.Brushes.Green);
            painter.DrawLine(triangle.vertexes[0], triangle.vertexes[2], System.Windows.Media.Brushes.Green);
        }

        bool testFlag;
        internal void testTriang(int n)
        {
            testFlag = false;
            clear2dPaintDesk();
            GeneratePoints(n);
            drawFigure();
        }

        internal void Triangulate()
        {
            testFlag = true;
            var pntsCopy = Points.Select(p => p).ToList();
            clear2dPaintDesk();
            Points = pntsCopy;
            drawFigure();
        }
    }
}
