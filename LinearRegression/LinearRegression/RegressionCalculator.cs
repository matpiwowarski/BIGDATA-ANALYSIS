using System;
using MathNet.Numerics.LinearAlgebra;

namespace LinearRegression
{
    public class RegressionCalculator
    {
        // X, Y
        public FunctionMatrices Matrices;
        // centered X
        public Matrix<double> X { get; set; }

        // mean(X)
        public double MeanX { get; set; }
        // b and c of function (ax^2 + bx + c)
        public double B { get; set; }
        public double C { get; set; }

        // methods

        public void CalculateRegression()
        {
            MeanX = CalculateMeanX();
            X = GetCenteredX();
            B = CalculateB();
            C = CalculateC();
        }

        private double CalculateC()
        {
            double realValue = Matrices.Y[0, 0];
            double regressionValue = B * Matrices.X[0, 0];
            double C = realValue - regressionValue;

            return C;
        }

        private double CalculateB()
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

        public RegressionCalculator(FunctionMatrices matrices)
        {
            Matrices = matrices;
        }

        private Matrix<double> GetCenteredX()
        {
            return Matrices.X.Subtract(MeanX);
        }
    }
}
