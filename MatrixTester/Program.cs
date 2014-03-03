using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecollopy_matrixCalculator;

namespace MatrixTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(new double[,] { { 1, 3 }, { -2, 4 } });
            Matrix matrix2 = new Matrix(new double[,] { { 5, 6 }, { 7, 8 } });
            int scalar = 2;

            Console.WriteLine("Matrix 1:");
            matrix1.Print();
            Console.WriteLine("");

            Console.WriteLine("Matrix 2:");
            matrix2.Print();
            Console.WriteLine("");

            Console.WriteLine("Matrix 1 + Matrix 2:");
            MatrixMath.Add(matrix1, matrix2).Print();
            Console.WriteLine("");

            Console.WriteLine("Matrix 1 - Matrix 2:");
            MatrixMath.Subtract(matrix1, matrix2).Print();
            Console.WriteLine("");

            Console.WriteLine("Matrix 1 * " + scalar);
            MatrixMath.Add(matrix1, matrix2).Print();
            Console.WriteLine("");

            Console.WriteLine("Matrix 1 * Matrix 2:");
            MatrixMath.Multiply(matrix1, matrix2).Print();
            Console.WriteLine("");

            Console.WriteLine("Matrix 1 Inverted:");
            MatrixMath.Invert(matrix1).Print();
            Console.WriteLine("");

            Console.ReadLine();
        }
    }
}
