using System;
using System.Collections.Generic;
using System.IO;

namespace LinearRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "data.txt"; //single.txt // multi.txt
            List<double> outputs = new List<double>();
            List<List<double>> columnsWithInputs = new List<List<double>>();

            // Read file using StreamReader. Reads file line by line    
            using (StreamReader file = new StreamReader(fileName))
            {
                string ln;

                ln = file.ReadLine();
                int numberOfVariables = HowManyVariablesInLine(ln);
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
            RegressionCalculator calculator = new RegressionCalculator(matrices);

            Console.WriteLine(calculator.B);
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
