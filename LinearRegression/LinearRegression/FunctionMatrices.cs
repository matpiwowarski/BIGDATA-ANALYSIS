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
        public Vector<double> Y;
        // mean(X)
        public double MeanX = 0;

        public FunctionMatrices(List<List<double>> columns, List<double> y)
        {
            X = Matrix<double>.Build.Dense(y.Count, columns.Count);

            FillMatrixWithColumns(columns);

            Y = Vector.Build.Dense(y.Count);

            FillVectorWithValues(y);
        }

        private void FillVectorWithValues(List<double> y)
        {
            for(int i = 0; i < y.Count; i++)
            {
                Y[i] = y[i];
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

        public void AddPoint(double x, double y)
        {
            X.Add(x);
            X.Add(y);
        }
    }
}
