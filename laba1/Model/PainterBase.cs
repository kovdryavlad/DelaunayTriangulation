using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SimpleMatrix;

namespace laba1.Model
{
    public abstract class PainterBase<T>
    {
        protected T m_paintDesk;
        protected double m_width;
        protected double m_height;

        public PainterBase(T paintDesk)
        {
            m_paintDesk = paintDesk;
        }

        public abstract void DrawPoint(Point point);
        public abstract void DrawLine(Point StartPoint, Point EndPoint);
        public abstract void ClearDesk();
    }
}
