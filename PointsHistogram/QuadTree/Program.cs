using System;
using System.IO;

namespace QuadTree
{
    class MainClass
    {
        public static int Main(string[] args)
        {
            /*if (args.Length < 2)
            {
                System.Console.WriteLine("Plese run program:\n program <input_file.txt> <preprocessed_file>");
                return 1;
            }
            else
            {*/
                QuadTree quadTree = new QuadTree();

                try
                {
                    // Read file using StreamReader. Reads file line by line    
                    using (StreamReader file = new StreamReader("test.txt")) // (args[0])
                    {
                        string ln;

                        while ((ln = file.ReadLine()) != null)
                        {
                            ln = ln.Replace(".", ",");
                            string[] tokens = ln.Split(' ');

                            double x = double.Parse(tokens[0]);
                            double y = double.Parse(tokens[1]);
                            double z = double.Parse(tokens[2]);
                            short i = short.Parse(tokens[3]);

                            Point point = new Point(x, y, z, i);

                            quadTree.Insert(point);
                        }
                        file.Close();
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            //}

            return 0;
        }
    }
}
