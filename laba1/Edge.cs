using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class Edge
    {
        public PointZ a;
        public PointZ b;

        public Edge(PointZ p1, PointZ p2)
        {
            a = p1;
            b = p2;
        }

        public bool Contains(PointZ point) => (a == point) || (b == point);

        public PointZ getSecondPoint(PointZ point) => a == point ? b : a;

        //public static bool operator ==(Edge e1, Edge e2) => ((e1.a == e2.a) && (e1.b == e2.b)) || ((e1.a == e2.b) && (e1.b == e2.a));
        //
        //public static bool operator !=(Edge e1, Edge e2) => !(e1 == e2);
    }
}
