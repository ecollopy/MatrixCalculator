﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecollopy_matrixCalculator
{
    //The Static MatrixMath class. To be instantiated wherever matrixes need mathing.
    public static class MatrixMath
    {
        public static Matrix Add(Matrix matrix1, Matrix matrix2)
        {
            int matrixSize = matrix1.GetSize();
            Matrix result = new Matrix(new double[matrixSize, matrixSize]);
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    result.SetValue(i, j, matrix1.GetValue(i, j) + matrix2.GetValue(i, j));
                }
            }
            return result;
        }

        public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
        {
            int matrixSize = matrix1.GetSize();
            Matrix result = new Matrix(new double[matrixSize, matrixSize]);
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    result.SetValue(i, j, matrix1.GetValue(i, j) - matrix2.GetValue(i, j));
                }
            }
            return result;
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            int matrixSize = matrix1.GetSize();
            Matrix result = new Matrix(new double[matrixSize, matrixSize]);
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    result.SetValue(i, j, 0);
                    for (int k = 0; k < matrixSize; k++)
                    {
                        result.SetValue(i, j, result.GetValue(i, j) + matrix1.GetValue(i, k) * matrix2.GetValue(k, j));
                    }
                }
            }
            return result;
        }

        public static Matrix Scale(Matrix matrix, double scalar)
        {
            int matrixSize = matrix.GetSize();
            Matrix result = new Matrix(new double[matrixSize, matrixSize]);
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    result.SetValue(i, j, matrix.GetValue(i, j) * scalar);
                }
            }
            return result;
        }

        public static Matrix Invert(Matrix matrix)
        {
            int matrixSize = matrix.GetSize();
            Matrix result;
            double determinant = GetDeterminant(matrix);
            if (matrix.GetSize() == 2)
            {
                result = new Matrix(new double[matrixSize, matrixSize]);
                result.SetValue(0, 0, matrix.GetValue(1, 1));
                result.SetValue(1, 0, ((-1) * (matrix.GetValue(1, 0))));
                result.SetValue(0, 1, ((-1) * (matrix.GetValue(0, 1))));
                result.SetValue(1, 1, matrix.GetValue(0, 0));
            }
            else
            {
                result = Adjoint(matrix);
            }
            return Scale(result, (1 / determinant));
        }

        public static double GetDeterminant(Matrix matrix)
        {
            int matrixSize = matrix.GetSize();
            double result = 0;
            if (matrixSize == 2)
            {
                result = ((matrix.GetValue(0, 0) * matrix.GetValue(1, 1)) - (matrix.GetValue(0, 1) * matrix.GetValue(1, 0)));
            }
            else
            {
                for (int i = 0; i < matrixSize; i++)
                {
                    Matrix minor = GetMinor(matrix, i, 0);
                    result += GetDeterminant(minor);
                }
            }
            return result;
        }

        public static Matrix GetMinor(Matrix matrix, int x, int y)
        {
            int matrixSize = matrix.GetSize() - 1;
            Matrix result = new Matrix(new double[matrixSize, matrixSize]);
            int rowVal, colVal;
            for (int i = 0; i < matrix.GetSize(); i++)
            {
                for (int j = 0; j < matrix.GetSize(); j++)
                {
                    if (i < x && j < y)
                    {
                        rowVal = i;
                        colVal = j;
                    }
                    else
                    {
                        if (i > x)
                        {
                            rowVal = i + 1;
                        }
                        else
                        {
                            rowVal = i;
                        }
                        if (j > y)
                        {
                            colVal = j + 1;
                        }
                        else
                        {
                            colVal = j;
                        }
                    }
                    if(i != x && j != y)
                        result.SetValue(i, j, matrix.GetValue(rowVal,colVal));
                }
            }
            return result;
        }

        public static Matrix Adjoint(Matrix matrix)
        {
            int matrixSize = matrix.GetSize();
            Matrix result = new Matrix(new double[matrixSize, matrixSize]);
            for (int i = 0; i < matrix.GetSize(); i++)
            {
                for (int j = 0; j < matrix.GetSize(); j++)
                {
                    Matrix cofactor = GetMinor(matrix, i, j);
                    result.SetValue(i, j, (Math.Pow(-1, (i + j)) * GetDeterminant(cofactor)));
                }
            }
            return Transpose(result);
        }

        public static Matrix Transpose(Matrix matrix)
        {
            int matrixSize = matrix.GetSize();
            Matrix result = new Matrix(new double[matrixSize, matrixSize]);
            for (int i = 0; i < matrix.GetSize(); i++)
            {
                for (int j = 0; j < matrix.GetSize(); j++)
                {
                    result.SetValue(i, j, (matrix.GetValue(j, i)));
                }
            }
            return result;
        }

        public static void Test(Matrix matrix1, Matrix matrix2, int scalar)
        {
            Console.WriteLine("Matrix 1:");
            matrix1.Print();
            Console.WriteLine("");

            Console.WriteLine("Matrix 2:");
            matrix2.Print();
            Console.WriteLine("");

            Console.WriteLine("Matrix 1 + Matrix 2:");
            Add(matrix1, matrix2).Print();
            Console.WriteLine("");

            Console.WriteLine("Matrix 1 - Matrix 2:");
            Subtract(matrix1, matrix2).Print();
            Console.WriteLine("");

            Console.WriteLine("Matrix 1 * " + scalar);
            Scale(matrix1, scalar).Print();
            Console.WriteLine("");

            Console.WriteLine("Matrix 1 * Matrix 2:");
            Multiply(matrix1, matrix2).Print();
            Console.WriteLine("");

            Console.WriteLine("Matrix 1 Inverted:");
            Invert(matrix1).Print();
            Console.WriteLine("");

            Console.ReadLine();
        }
    }
}
