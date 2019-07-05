using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using SimpleMatrix;

namespace laba1.Model
{
    public class CanvasPainter : PainterBase<Canvas>
    {
        public CanvasPainter(Canvas paintDesk) 
            : base(paintDesk)
        {
            m_width = paintDesk.ActualWidth;
            m_height = paintDesk.ActualHeight;
        }

        public override void ClearDesk()
        {
            
             m_paintDesk.Children.Clear();
        }

        public override void DrawLine(Point StartPoint, Point EndPoint)
        {
            DrawLine(StartPoint, EndPoint, Brushes.Black);
        }

        public void DrawLine(Point StartPoint, Point EndPoint, SolidColorBrush brush)
        {
            Line line = new Line()
            {
                Stroke = brush,

                X1 = StartPoint.X,
                Y1 = m_height - StartPoint.Y,

                X2 = EndPoint.X,
                Y2 = m_height - EndPoint.Y,
                StrokeThickness = 2
            };

            m_paintDesk.Children.Add(line);
        }

        public override void DrawPoint(Point point)
        {
            DrawPoint(point, Brushes.Red);
        }

        public void DrawPoint(Point point, SolidColorBrush brush)
        {
            Ellipse elipse = new Ellipse
            {
                Width = 4,
                Height = 4,
                StrokeThickness = 2,
                Stroke = brush,
                Margin = new System.Windows.Thickness(point.X - 2, m_height- point.Y - 2, 0, 0)
            };

            m_paintDesk.Children.Add(elipse);
        }
    }
}
