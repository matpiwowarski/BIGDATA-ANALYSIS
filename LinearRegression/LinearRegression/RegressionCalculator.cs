using System;
using MathNet.Numerics.LinearAlgebra;

namespace LinearRegression
{
    public class RegressionCalculator
    {
        // X, Y
        public FunctionMatrices Matrices;
        // centered
        public Matrix<double> X { get; set; }

        // mean(X)
        public double MeanX
        {
            get
            {
                return CalculateMeanX();
            }
            set
            {
                MeanX = value;
            }
        }
        // b of function (ax^2 + bx + c)
        public double B
        {
            get
            {
                return CalculateB();
            }
            set
            {
                B = value;
            }
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
            GetCenteredX();
        }

        private void GetCenteredX()
        {
            X = Matrices.X.Subtract(MeanX);
        }
    }
}
