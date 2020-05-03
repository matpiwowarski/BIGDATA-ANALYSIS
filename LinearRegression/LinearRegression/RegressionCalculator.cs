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
        public Matrix<double> X;

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
            double realValue = 0;
            double regressionValue = 0;
            List<double> differences = new List<double>();


                for(int j = 0; j < Matrices.Y.RowCount; j++)
                {
                    realValue = Matrices.Y[j, 0];

                    for (int i = 0; i < NumberOfXVariables; i++)
                    {
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
                var matrix = X.Transpose().Multiply(X);

                double determinant = matrix.Determinant();
                double inversion = 1 / determinant;

                var matrix2 = X.Transpose().Multiply(inversion);

                var b = matrix2.Multiply(Y).Determinant();

                B.Add(b);
            }
            
        }

        private void CalculateMeanX()
        {
            Vector<double> columnSums = Matrices.X.ColumnSums();

            for(int i = 0; i < NumberOfXVariables; i++)
            {
                double sum = columnSums[i];
                double mean = sum / Matrices.X.RowCount;
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
            X = Matrix<double>.Build.Dense(Matrices.X.RowCount, Matrices.X.ColumnCount);
            Matrices.X.CopyTo(X);

            for(int i = 0; i < NumberOfXVariables; i++)
            {
                for(int j = 0; j < X.RowCount; j++)
                {
                    X[j, i] = X[j, i] - MeanX[i];
                }
            }
        }
    }
}
