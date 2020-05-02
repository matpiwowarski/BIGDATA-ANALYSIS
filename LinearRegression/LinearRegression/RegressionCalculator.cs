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
        public Matrix<double> X { get; set; }

        // mean(X)
        public double MeanX { get; set; }
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
            MeanX = CalculateMeanX();
            X = GetCenteredX();
            B.Add(CalculateB(0));
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

        private double CalculateB(int index)
        {
            var Y = Matrices.Y;
            var matrix = X.Transpose().Multiply(X);

            double determinant = matrix.Determinant();
            double inversion = 1 / determinant;

            var matrix2 = X.Transpose().Multiply(inversion);

            var b = matrix2.Multiply(Y).Determinant();

            return b;
        }

        private double CalculateMeanX()
        {
            double sum = 0;
            double mean = 0;

            Vector<double> columnSums = Matrices.X.ColumnSums();

            foreach(double columnSum in columnSums)
            {
                sum += columnSum;
            }

            mean = sum / (Matrices.X.ColumnCount * Matrices.X.RowCount);

            return mean;
        }

        public RegressionCalculator(FunctionMatrices matrices, int number)
        {
            NumberOfXVariables = number;
            Matrices = matrices;
        }

        private Matrix<double> GetCenteredX()
        {
            return Matrices.X.Subtract(MeanX);
        }
    }
}
