using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Matrix
    {
        private double[,] data;
        public int Rows { get; }
        public int Cols { get; }

        public Matrix(double[,] values)
        {
            Rows = values.GetLength(0);
            Cols = values.GetLength(1);
            data = (double[,])values.Clone();
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                Console.WriteLine("Chyba: Matice musí mít stejné rozměry pro sčítání.");
                return null;
            }

            double[,] result = new double[a.Rows, a.Cols];
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    result[i, j] = a.data[i, j] + b.data[i, j];

            return new Matrix(result);
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                Console.WriteLine("Chyba: Matice musí mít stejné rozměry pro odčítání.");
                return null;
            }
            double[,] result = new double[a.Rows, a.Cols];
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    result[i, j] = a.data[i, j] - b.data[i, j];

            return new Matrix(result);
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
            {
                Console.WriteLine("Chyba: Nevhodné rozměry matic pro násobení");
                return null;
            }
               

            double[,] result = new double[a.Rows, b.Cols];
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < b.Cols; j++)
                    for (int k = 0; k < a.Cols; k++)
                        result[i, j] += a.data[i, k] * b.data[k, j];

            return new Matrix(result);
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                return false;
            }

            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    if (a.data[i, j] != b.data[i, j])
                        return false;

            return true;
        }

        public static bool operator !=(Matrix a, Matrix b) => !(a == b);

        public static Matrix operator -(Matrix a)
        {
            double[,] result = new double[a.Rows, a.Cols];
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    result[i, j] = -a.data[i, j];

            return new Matrix(result);
        }

        public double Determinant()
        {
            if (Rows != Cols)
            {
                Console.WriteLine("Determinant lze vypočítat pouze ze čtvercové matice.");
                return 0;
            }
                
            if (Rows > 3)
            {
                Console.WriteLine("Výpočet determinantu je podporován pouze do velikosti matice 3x3.");
                return 0;
            }
             

            if (Rows == 1) return data[0, 0];
            if (Rows == 2) return data[0, 0] * data[1, 1] - data[0, 1] * data[1, 0];

            return data[0, 0] * (data[1, 1] * data[2, 2] - data[1, 2] * data[2, 1])
                 - data[0, 1] * (data[1, 0] * data[2, 2] - data[1, 2] * data[2, 0])
                 + data[0, 2] * (data[1, 0] * data[2, 1] - data[1, 1] * data[2, 0]);
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    result += data[i, j] + " ";
                result += "\n";
            }
            return result;
        }
    }

}
