using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecollopy_matrixCalculator
{
    public class Matrix
    {
        private double[,] values;
        private int sideSize;

        public Matrix(double[,] values)
        {
            this.values = values;
            sideSize = (int) Math.Sqrt(values.Length);
        }

        public int GetSize()
        {
            return sideSize;
        }

        public double GetValue(int x, int y)
        {
            return values[x, y];
        }

        public void SetValue(int x, int y, double value)
        {
            values[x, y] = value;
        }

        public void Print()
        {
            for (int i = 0; i < values.GetLength(0); i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    Console.Write(values[i, j] + " ");
                }
                Console.Write("]\n");
            }
        }
    }
}
