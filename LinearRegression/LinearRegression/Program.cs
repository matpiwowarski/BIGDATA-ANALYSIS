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
            // single.txt: C = 7.1594;  B = { 3.1000; } Y(400) = 1247.2; (works)
            // multi.txt:  C = 1.0441;  B = { 0.1000; 11.100; 5.2001; 4.4000; } (works) 
            // poly.txt:   C = 61005.0; B = { 5.6097; -0.031; 2.0968; -1.099; } (works)
            string filePath = AskUserForFileName();
            bool isPolynomial;

            List<double> Y = new List<double>();
            List<List<double>> XColumns = new List<List<double>>();

            ReadDataIntoLists(filePath, XColumns, Y);

            if(XColumns.Count > 1)
            {
                isPolynomial = false;
            }
            else
            {
                isPolynomial = true;
            }

            int degree = 1;
            RegressionCalculator calculator;
            Results results = new Results();
            do
            {
                FunctionMatrices matrices = new FunctionMatrices(XColumns, Y, isPolynomial, degree);
                calculator = new RegressionCalculator(matrices, XColumns.Count, isPolynomial, degree);
                calculator.CalculateRegression();

                var lastParameter = calculator.B[calculator.B.RowCount - 1, 0];
                if (lastParameter < 0.01 && lastParameter > -0.01)
                    break;

                results = new Results(calculator.B, calculator.C);
                degree++;
            }
            while (isPolynomial);
            degree--;

            results.DisplayRegressionInfo(isPolynomial, degree, calculator);
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
