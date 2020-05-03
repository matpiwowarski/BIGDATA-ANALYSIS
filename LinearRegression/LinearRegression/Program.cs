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
            //single.txt: 7.1594; 3.1000; 1247.2; (works)

            string fileName = "single.txt";  // multi.txt // poly.txt
            List<double> outputs = new List<double>();
            List<List<double>> columnsWithInputs = new List<List<double>>();

            int numberOfVariables = 0;

            // Read file using StreamReader. Reads file line by line    
            using (StreamReader file = new StreamReader(fileName))
            {
                string ln;

                ln = file.ReadLine();
                numberOfVariables = HowManyVariablesInLine(ln);
                CreateColumns(columnsWithInputs, numberOfVariables);

                while ((ln = file.ReadLine()) != null)
                {
                    ln = ln.Replace(".", ",");
                    string[] tokens = ln.Split(' ');

                    for(int i = 0; i < numberOfVariables; i++)
                    {
                        if (i + 1 == numberOfVariables) // save output
                        {
                            double value = double.Parse(tokens[i]);
                            outputs.Add(value);
                        }
                        else // save input
                        {
                            double value = double.Parse(tokens[i]);
                            columnsWithInputs[i].Add(value);
                        }
                    }

                }
                file.Close();
            }
            FunctionMatrices matrices = new FunctionMatrices(columnsWithInputs, outputs);
            RegressionCalculator calculator = new RegressionCalculator(matrices, numberOfVariables - 1);

            calculator.CalculateRegression();
            DisplayRegressionInfo(calculator);
        }

        private static void DisplayRegressionInfo(RegressionCalculator calculator)
        {
            Console.WriteLine("c: " + calculator.C);
            for (int i = 0; i < calculator.NumberOfXVariables; i++)
            {
                Console.WriteLine("b" + (i + 1) + " : " + calculator.B[i, 0]);
            }

            bool askForFunctionValue = true;

            while(askForFunctionValue)
            {
                Console.WriteLine("\nWould you like to know the value of regression function for your parameters?\n (Y/N)");
                string input = Console.ReadLine();
                input = input.ToUpper();

                if(input == "Y")
                {
                    Console.Clear();
                    AskUserForFunctionValue(calculator);
                }
                else
                {
                    askForFunctionValue = false;
                }
            }
        }

        private static void AskUserForFunctionValue(RegressionCalculator calculator)
        {
            List<double> parameters = new List<double>();

            for(int i = 0; i < calculator.X.ColumnCount; i++)
            {
                Console.WriteLine("Put value of X" + (i + 1));
                double value = Convert.ToDouble(Console.ReadLine());
                parameters.Add(value);
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

            Console.WriteLine(builder.ToString() + calculator.GetFunctionValue(parameters));
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
