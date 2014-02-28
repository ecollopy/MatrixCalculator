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
        private int sideSize;

        public Matrix(double[,] values)
        {
            this.values = values;
            sideSize = values.Length;
        }

        public double GetValue(int x, int y)
        {
            return values[x, y];
        }

        public int GetSize()
        {
            return sideSize;
        }
    }
}
