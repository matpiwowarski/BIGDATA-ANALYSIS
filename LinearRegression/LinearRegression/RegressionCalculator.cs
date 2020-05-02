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
        public double MeanX = 0;
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
            double realValue = 0;
            double regressionValue = 0;
            List<double> differences = new List<double>();

            for (int i = 0; i < NumberOfXVariables; i++)
            {
                for(int j = 0; j < Matrices.Y.RowCount; j++)
                {
                    realValue = Matrices.Y[j, 0];
                    regressionValue = B[i] * Matrices.X[j, i];
                    double C = realValue - regressionValue;
                    differences.Add(C);
                }
            }

            double mean = GetSumOfDoubleList(differences) / differences.Count;

            return mean;
        }

        private double GetSumOfDoubleList(List<double> differences)
        {
            double sum = 0;
            foreach(double value in differences)
            {
                sum += value;
            }

            return sum;
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

            double sum = 0;
            for(int i = 0; i < NumberOfXVariables; i++)
            {
                sum += columnSums[i];
            }

            MeanX = sum / (Matrices.X.RowCount * Matrices.X.ColumnCount);
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
                var subtractedColumn = column.Subtract(MeanX);
                X.Add(subtractedColumn.ToColumnMatrix());
            }
        }
    }
}
