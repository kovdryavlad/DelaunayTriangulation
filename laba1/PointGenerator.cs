using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    public class PointGenerator
    {
        Random rand = new Random();
        public int Width { get; set; }
        public int Height { get; set; }

        public PointGenerator(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        int margin = 10; 

        public List<PointZ> Generate(int n)
        {
            var points = new List<PointZ>();
            for (var index = 0; index < n; index++)
            {
                points.Add(new PointZ(
                   rand.Next(margin, this.Width),
                   rand.Next(margin, this.Height)
                ));
            }
            return points;
        }
    }
}
