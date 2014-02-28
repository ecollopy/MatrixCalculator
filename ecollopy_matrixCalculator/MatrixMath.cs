	﻿using System;
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
	            Matrix result = null;
	            return result;
	        }
	
	        public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
	        {
	            Matrix result = null;
	            return result;
	        }
	
	        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
	        {
	            Matrix result = null;
	            return result;
	        }
	
	        public static Matrix Scale(Matrix matrix, double scalar)
	        {
	            Matrix result = null;
	            return result;
	        }
	
	        public static Matrix Invert(Matrix matrix)
	        {
                double[,] values = new double[matrix.GetSize(), matrix.GetSize()];
                double determinant = GetDeterminant(matrix);
                Matrix result;
                if (matrix.GetSize() == 2)
                {
                    values[0, 0] = matrix.GetValue(1, 1);
                    values[0, 1] = (-1) * matrix.GetValue(1, 0);
                    values[1, 0] = (-1) * matrix.GetValue(0, 1);
                    values[1, 1] = matrix.GetValue(0, 0);
                    result = new Matrix(values);
                }
                else
                {
                    result = Adjoint(matrix);
                }
	            return Scale(result, (1/determinant));
	        }

            public static double GetDeterminant(Matrix matrix)
            {
                double result = 0;
                if (matrix.GetSize() == 2)
                {
                    result = ((matrix.GetValue(0,0)*matrix.GetValue(1,1))-(matrix.GetValue(0,1)*matrix.GetValue(1,0)));
                }
                else
                {
                    for (int i = 0; i < matrix.GetSize(); i++)
                    {
                        Matrix minor = GetMinor(matrix, i, 0);
                    }
                }
                return result;
            }

            public static Matrix GetMinor(Matrix matrix, int x, int y)
            {
                double[,] result = new double[matrix.GetSize()-1, matrix.GetSize()-1];
                for (int i = 0; i < matrix.GetSize(); i++)
                {
                    for (int j = 0; j < matrix.GetSize(); j++)
                    {

                    }
                }
                return new Matrix(result);
            }

            public static Matrix Adjoint(Matrix matrix)
            {
                double[,] values = new double[matrix.GetSize(), matrix.GetSize()];
                for (int i = 0; i < matrix.GetSize(); i++)
                {
                    for (int j = 0; j < matrix.GetSize(); j++)
                    {
                        Matrix cofactor = GetMinor(matrix, i, j);
                        values[i, j] = Math.Pow(-1, (i+j)) * GetDeterminant(cofactor);
                    }
                }
                Matrix result = new Matrix(values);
                return Transpose(result);
            }

            public static Matrix Transpose(Matrix matrix)
            {
                double[,] result = new double[matrix.GetSize(), matrix.GetSize()];
                for (int i = 0; i < matrix.GetSize(); i++)
                {
                    for (int j = 0; j < matrix.GetSize(); j++)
                    {
                        result[i,j] = matrix.GetValue(j,i);
                    }
                }
                return new Matrix(result);
            }
	    }
	}