using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SimpleMatrix;

namespace laba1.Model._3d
{
    public static class MatrixHelper
    {
        public static PointZ[] GetPointsInDecartSystem(this Matrix matrix)
        {
            List<PointZ> result = new List<PointZ>();

            int rows = matrix.Rows;
            int lastCoordIndex = matrix.Columns - 1;

            for (int i = 0; i < rows; i++)
            {
                var currentRow = matrix.GetRow(i);

                result.Add(
                    new PointZ(currentRow[0] , currentRow[1])
                    );
            }

            return result.ToArray();
        }

        public static Matrix AddPoint2d(this Matrix matrix, double x, double y)
        {
            var rows = matrix.Rows;

            var data = matrix.GetDataByReference();
            var newData = ArrayMatrix.GetJaggedArray(rows + 1, matrix.Columns);

            for (int i = 0; i < rows; i++)
                newData[i] = data[i];

            newData[rows] = new double[] { x, y};
            return new Matrix(newData);
        }
    }
}
