using System;
using System.Collections.Generic;
using System.IO;

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

            Console.WriteLine("c: " + calculator.C);
            for (int i = 0; i < calculator.NumberOfXVariables; i++)
            {
                Console.WriteLine("b" + (i + 1) + " : " + calculator.B[i]);
            }
            Console.WriteLine("y(400): " + calculator.GetFunctionValue(400));
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
