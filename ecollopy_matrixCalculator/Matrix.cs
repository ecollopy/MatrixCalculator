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

        public Matrix Add(Matrix m)
        {
            double[,] results = new double[m.sideSize, m.sideSize];
            return new Matrix(results);
        }

        public Matrix Subtract(Matrix m)
        {
            double[,] results = new double[m.sideSize, m.sideSize];
            return new Matrix(results);
        }

        public Matrix Scale(Matrix m, double scalar)
        {
            double[,] results = new double[m.sideSize, m.sideSize];
            return new Matrix(results);
        }

        public Matrix Multiply(Matrix m)
        {
            double[,] results = new double[m.sideSize, m.sideSize];
            return new Matrix(results);
        }

        public Matrix GetInverse(Matrix m)
        {
            double[,] results = new double[m.sideSize, m.sideSize];
            return new Matrix(results);
        }
    }
}
