using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LinearRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            // single.txt: C = 7.1594; B = { 3.1000; } Y(400) = 1247.2; (works)
            // multi.txt:  C = 1.0441; B = { 0.1000; 11.100; 5.2001; 4.4000; } (works) 
            // poly.txt
            string filePath = "poly.txt"; //AskUserForFileName();
            bool isPolynomial = true;
            int degree = 2;

            List<double> Y = new List<double>();
            List<List<double>> XColumns = new List<List<double>>();

            ReadDataIntoLists(filePath, XColumns, Y);

            FunctionMatrices matrices = new FunctionMatrices(XColumns, Y, isPolynomial, degree);
            RegressionCalculator calculator = new RegressionCalculator(matrices, XColumns.Count, isPolynomial);

            calculator.CalculateRegression();
            DisplayRegressionInfo(calculator, isPolynomial, degree);
        }

        private static void DisplayRegressionInfo(RegressionCalculator calculator, bool isPolynomial, int degree)
        {
            Console.WriteLine("c: " + calculator.C);
            if(isPolynomial)
            {
                for (int i = 0; i < degree; i++)
                {
                    Console.WriteLine("b" + (i + 1) + " : " + calculator.B[i, 0]);
                }
            }
            else
            {
                for (int i = 0; i < calculator.NumberOfXVariables; i++)
                {
                    Console.WriteLine("b" + (i + 1) + " : " + calculator.B[i, 0]);
                }
            }

            bool askForFunctionValue = true;

            while(askForFunctionValue)
            {
                Console.WriteLine("\nWould you like to know the value of regression function for your parameters?\n(Y/N)");
                string input = Console.ReadLine();
                input = input.ToUpper();

                if(input == "Y")
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

        private static void ReadDataIntoLists(string filePath, List<List<double>> XColumns, List<double> Y)
        {
            int numberOfVariables = 0;

            // Read file using StreamReader. Reads file line by line    
            using (StreamReader file = new StreamReader(filePath))
            {
                string ln;

                ln = file.ReadLine();
                numberOfVariables = HowManyVariablesInLine(ln);
                CreateColumns(XColumns, numberOfVariables);

                while ((ln = file.ReadLine()) != null)
                {
                    ln = ln.Replace(".", ",");
                    string[] tokens = ln.Split(' ');

                    for (int i = 0; i < numberOfVariables; i++)
                    {
                        if (i + 1 == numberOfVariables) // save output
                        {
                            double value = double.Parse(tokens[i]);
                            Y.Add(value);
                        }
                        else // save input
                        {
                            double value = double.Parse(tokens[i]);
                            XColumns[i].Add(value);
                        }
                    }

                }
                file.Close();
            }
        }

        private static string AskUserForFileName()
        {
            Console.WriteLine("Put file name or file path (e.g. single.txt):");
            string filePath = Console.ReadLine();
            return filePath;
        }

        private static void AskUserForFunctionValue(RegressionCalculator calculator, bool isPolynomial, int degree)
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


        private static void CreateColumns(List<List<double>> columnsWithInputs, int numberOfVariables)
        {
            int numberOfColumns = numberOfVariables - 1;
            for(int i = 0; i < numberOfColumns; i++)
            {
                columnsWithInputs.Add(new List<double>());
            }
        }

        private static int HowManyVariablesInLine(string ln)
        {
            int count = 1; // one is the result
            foreach(char x in ln)
            {
                if (x == ' ')
                    count++;
            }

            return count;
        }
    }
}
