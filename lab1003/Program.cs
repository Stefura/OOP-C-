using System;

class Matrix
{
    private double[,] data;

    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public Matrix(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        data = new double[rows, columns];
    }

    public double this[int row, int column]
    {
        get
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new IndexOutOfRangeException("Index is out of range.");

            return data[row, column];
        }
        set
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new IndexOutOfRangeException("Index is out of range.");

            data[row, column] = value;
        }
    }

    public static Matrix operator -(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            throw new ArgumentException("Matrix dimensions must be equal.");

        Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }

        return result;
    }

    public static Matrix operator -(Matrix matrix, double value)
    {
        Matrix result = new Matrix(matrix.Rows, matrix.Columns);

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                result[i, j] = matrix[i, j] - value;
            }
        }

        return result;
    }

    public static bool operator ==(Matrix matrix1, Matrix matrix2)
    {
        if (ReferenceEquals(matrix1, matrix2))
            return true;

        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            return false;

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                if (matrix1[i, j] != matrix2[i, j])
                    return false;
            }
        }

        return true;
    }

    public static bool operator !=(Matrix matrix1, Matrix matrix2)
    {
        return !(matrix1 == matrix2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Matrix matrix1 = new Matrix(2, 2);
        matrix1[0, 0] = 1.0;
        matrix1[0, 1] = 2.0;
        matrix1[1, 0] = 3.0;
        matrix1[1, 1] = 4.0;

        Matrix matrix2 = new Matrix(2, 2);
        matrix2[0, 0] = 2.0;
        matrix2[0, 1] = 3.0;
        matrix2[1, 0] = 4.0;
        matrix2[1, 1] = 5.0;

        Matrix difference = matrix1 - matrix2;
        Console.WriteLine("Різниця матриць:");
        PrintMatrix(difference);

        Matrix subtractedMatrix = matrix1 - 2.0;
        Console.WriteLine("Відняте число з матриці:");
        PrintMatrix(subtractedMatrix);

        bool isEqual = matrix1 == matrix2;
        Console.WriteLine("Перевірка на рівність: " + isEqual);
    }

    static void PrintMatrix(Matrix matrix)
    {
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
