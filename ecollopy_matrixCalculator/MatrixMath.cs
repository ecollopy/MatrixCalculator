using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecollopy_matrixCalculator
{
    //The Static MatrixMath class. To be instantiated wherever matrixes need mathing.
    static class MatrixMath
    {
        public static Matrix Add(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(new double[matrix1.GetSize(),matrix1.GetSize()]);
            for (int i = 0; i < matrix1.GetSize(); i++)
            {
                for (int j = 0; j < matrix1.GetSize(); j++)
                {
                    result.SetValue(i, j, matrix1.GetValue(i, j) + matrix2.GetValue(i, j));
                }
            }
            return result;
        }

        public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(new double[matrix1.GetSize(), matrix1.GetSize()]);
            for (int i = 0; i < matrix1.GetSize(); i++)
            {
                for (int j = 0; j < matrix1.GetSize(); j++)
                {
                    result.SetValue(i, j, matrix1.GetValue(i, j) - matrix2.GetValue(i, j));
                }
            }
            return result;
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(new double[matrix1.GetSize(), matrix1.GetSize()]);
            for (int i = 0; i < matrix1.GetSize(); i++)
            {
                for (int j = 0; j < matrix1.GetSize(); j++)
                {
                    result.SetValue(i, j, 0);
                    for (int k = 0; k < matrix1.GetSize(); k++)
                    {
                        result.SetValue(i, j, result.GetValue(i, j) + matrix1.GetValue(i, k) * matrix2.GetValue(k, j));
                    }
                }
            }
            return result;
        }

        public static Matrix Scale(Matrix matrix, double scalar)
        {
            Matrix result = null;
            return result;
        }

        public static Matrix Invert(Matrix matrix)
        {
            Matrix result = null;
            return result;
        }
    }
}
