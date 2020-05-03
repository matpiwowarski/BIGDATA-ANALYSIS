using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace LinearRegression
{
    public class Results
    {
        public double C { get; set; }
        public List<double> B = new List<double>();

        public Results() { }

        public Results(Matrix<double> B, double C)
        {
            for(int i = 0; i < B.RowCount; i++)
            {
                this.B.Add(B[i, 0]);
            }

            this.C = C;
        }

        public void DisplayRegressionInfo(bool isPolynomial, int degree, RegressionCalculator calculator)
        {
            Console.WriteLine("c: " + C);
            if (isPolynomial)
            {
                for (int i = 0; i < degree; i++)
                {
                    Console.WriteLine("b" + (i + 1) + " : " + B[i]);
                }
            }
            else
            {
                for (int i = 0; i < calculator.NumberOfXVariables; i++)
                {
                    Console.WriteLine("b" + (i + 1) + " : " + B[i]);
                }
            }

            bool askForFunctionValue = true;

            while (askForFunctionValue)
            {
                Console.WriteLine("\nWould you like to know the value of regression function for your parameters?\n(Y/N)");
                string input = Console.ReadLine();
                input = input.ToUpper();

                if (input == "Y")
                {
                    Console.Clear();
                    AskUserForFunctionValue(calculator, isPolynomial, degree);
                }
                else
                {
                    askForFunctionValue = false;
                }
            }
        }

        private void AskUserForFunctionValue(RegressionCalculator calculator, bool isPolynomial, int degree)
        {
            List<double> parameters = new List<double>();

            if (isPolynomial)
            {
                Console.WriteLine("Put value of X");
                double value = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                parameters.Add(value);
            }
            else
            {
                for (int i = 0; i < calculator.X.ColumnCount; i++)
                {
                    Console.WriteLine("Put value of X" + (i + 1));
                    double value = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
                    parameters.Add(value);
                }
            }

            // string with parameters
            StringBuilder builder = new StringBuilder();
            builder.Append("y( ");
            for (int i = 0; i < parameters.Count; i++)
            {
                builder.Append(parameters[i]);
                builder.Append(" ");
            }
            builder.Append(") = ");

            Console.WriteLine(builder.ToString() + calculator.GetFunctionValue(parameters, isPolynomial, degree));
        }
    }
}
