using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace LinearRegression
{
    public class FunctionMatrices
    {
        // X, Y
        public Matrix<double> X;
        public Matrix<double> Y;

        public FunctionMatrices(List<List<double>> columns, List<double> y, bool isPolynomial, int degree)
        {
            if(isPolynomial)
            {
                X = Matrix<double>.Build.Dense(y.Count, degree);
                FillMatrixWithColumns(columns[0], degree);
            }
            else
            {
                X = Matrix<double>.Build.Dense(y.Count, columns.Count);
                FillMatrixWithColumns(columns);
            }

            Y = Matrix<double>.Build.Dense(y.Count, 1);

            FillVectorWithValues(y);
        }

        private void FillVectorWithValues(List<double> y)
        {
            for(int i = 0; i < y.Count; i++)
            {
                Y[i, 0] = y[i];
            }
        }

        private void FillMatrixWithColumns(List<List<double>> columns)
        {
            // for each column
            for(int i = 0; i < columns.Count; i++)
            {
                // for each row in column
                for (int j = 0; j < columns[i].Count; j++)
                {
                    X[j, i] = columns[i][j];
                }
            }
        }

        private void FillMatrixWithColumns(List<double> column, int degree)
        {
            int pow = 1;
            // for each column
            for (int i = 0; i < degree; i++)
            {
                // for each row in column
                for (int j = 0; j < column.Count; j++)
                {
                    X[j, i] = Math.Pow(column[j], pow);
                }
                pow++;
            }
        }

        public void AddPoint(double x, double y)
        {
            X.Add(x);
            X.Add(y);
        }
    }
}
