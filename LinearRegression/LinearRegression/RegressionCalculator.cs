using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace LinearRegression
{
    public class RegressionCalculator
    {
        public int NumberOfXVariables;
        // X, Y
        public FunctionMatrices Matrices;
        // centered X
        public List<Matrix<double>> X = new List<Matrix<double>>();

        // mean(X)
        public List<double> MeanX = new List<double>();
        // b and c of function (ax^2 + bx + c)
        public List<double> B = new List<double>();

        public double C { get; set; }

        // methods

        public double GetFunctionValue(double x)
        {
            double y = C;

            for(int i = 0; i < NumberOfXVariables; i++)
            {
                y += B[i] * x;
                x = x * x;
            }

            return y;
        }

        public void CalculateRegression()
        {
            CalculateMeanX();
            GetCenteredX();
            CalculateB();
            C = CalculateC();
        }

        private double CalculateC()
        {
            double realValue = Matrices.Y[0, 0];
            double regressionValue = 0;
            for (int i = 0; i < NumberOfXVariables; i++)
            {
                regressionValue = B[i] * Matrices.X[0, 0];
            }

            double C = realValue - regressionValue;

            return C;
        }

        private void CalculateB()
        {
            var Y = Matrices.Y;

            for(int index = 0; index < NumberOfXVariables; index++)
            {
                var matrix = X[index].Transpose().Multiply(X[index]);

                double determinant = matrix.Determinant();
                double inversion = 1 / determinant;

                var matrix2 = X[index].Transpose().Multiply(inversion);

                var b = matrix2.Multiply(Y).Determinant();

                B.Add(b);
            }
        }

        private void CalculateMeanX()
        {
            Vector<double> columnSums = Matrices.X.ColumnSums();

            for(int i = 0; i < NumberOfXVariables; i++)
            {
                double mean = columnSums[i] / Matrices.X.RowCount;
                MeanX.Add(mean);
            }
        }

        public RegressionCalculator(FunctionMatrices matrices, int number)
        {
            NumberOfXVariables = number;
            Matrices = matrices;
        }

        private void GetCenteredX()
        {
            for(int i = 0; i < NumberOfXVariables; i++)
            {
                Vector<double> column = Matrices.X.Column(i);
                var subtractedColumn = column.Subtract(MeanX[i]);
                X.Add(subtractedColumn.ToColumnMatrix());
            }
        }
    }
}
