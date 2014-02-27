using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecollopy_matrixCalculator
{
    class Matrix
    {
        private double[,] values;
        public Matrix(int side)
        {
            values = new double[side, side];
        }

        public double GetValue(int x, int y)
        {
            return values[x, y];
        }
    }
}
