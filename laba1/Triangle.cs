using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class Triangle
    {
        //public PointZ a, b, c;

        public PointZ[] vertexes; 

        public List<Edge> edges = new List<Edge>();

        public Triangle(PointZ a, PointZ b, PointZ c)
        {
            vertexes = new PointZ[3];

            vertexes[0] = a;
            vertexes[1] = b;
            vertexes[2] = c;

            edges.Add(new Edge(a, b));
            edges.Add(new Edge(a, c));
            edges.Add(new Edge(b, c));
        }

        public bool Contains(PointZ point) => vertexes.Contains(point);

        public PointZ GetThirdVertex(PointZ[] inputPoints)
        {
            return vertexes.Except(inputPoints).ToArray()[0];
        } 
    }
}
