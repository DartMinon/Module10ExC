using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MatrixOperators
{
    public class Matrix
    {
        int[,] data;
        public Matrix(int size)
        {
            data = new int[size, size];
        }
        public int this[int RowIndex, int ColumnIndex]
        {
            get
            {
                return data[RowIndex, ColumnIndex];
            }
            set
            {
                data[RowIndex, ColumnIndex] = value;
            }
        }
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.data.GetLength(0) == matrix2.data.GetLength(0))
            {
                Matrix newMatrix = new Matrix(matrix1.data.GetLength(0));
                for (int x = 0; x < matrix1.data.GetLength(0); x++)
                {
                    for (int y = 0; y < matrix1.data.GetLength(1); y++)
                    {
                        newMatrix.data[x, y] = matrix1.data[x, y] + matrix2.data[x, y];
                    }
                }
                return newMatrix;
            }
            else
            {
                throw new MatrixNotCompatibleException(matrix1, matrix2, "Matrices not the same size.");
            }
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.data.GetLength(0) == matrix2.data.GetLength(0))
            {
                Matrix newMatrix = new Matrix(matrix1.data.GetLength(0));
                for (int x = 0; x < matrix1.data.GetLength(0); x++)
                {
                    for (int y = 0; y < matrix1.data.GetLength(1); y++)
                    {
                        newMatrix.data[x, y] = matrix1.data[x, y] - matrix2.data[x, y];
                    }
                }
                return newMatrix;
            }
            else
            {
                throw new MatrixNotCompatibleException(matrix1, matrix2, "Matrices not the same size.");
            }
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.data.GetLength(0) == matrix2.data.GetLength(0))
            {
                Matrix newMatrix = new Matrix(matrix1.data.GetLength(0));

                // Iterate over every row in the matrix.
                for (int x = 0; x < matrix1.data.GetLength(0); x++)
                {
                    // Iterate over every column in the matrix.
                    for (int y = 0; y < matrix1.data.GetLength(1); y++)
                    {
                        int temp = 0;
                        for (int z = 0; z < matrix1.data.GetLength(0); z++)
                        {
                            temp += matrix1.data[x, z] * matrix2.data[z, y];
                        }
                        newMatrix.data[x, y] = temp;
                    }
                }
                return newMatrix;
            }
            else
            {
                throw new MatrixNotCompatibleException(matrix1, matrix2, "Matrices not the same size.");
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    builder.AppendFormat("{0}\t", data[x, y]);
                }
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }
    }

    public class MatrixNotCompatibleException : Exception
    {
        Matrix firstMatrix = null;
        Matrix secondMatrix = null;

        public Matrix FirstMatrix
        {
            get
            {
                return firstMatrix;
            }
        }

        public Matrix SecondMatrix
        {
            get
            {
                return firstMatrix;
            }
        }

        public MatrixNotCompatibleException()
            : base()
        {
        }

        public MatrixNotCompatibleException(string message)
            : base(message)
        {
        }

        public MatrixNotCompatibleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public MatrixNotCompatibleException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public MatrixNotCompatibleException(Matrix matrix1, Matrix matrix2, string message)
            : base(message)
        {
            firstMatrix = matrix1;
            secondMatrix = matrix2;
        }
    }
}
