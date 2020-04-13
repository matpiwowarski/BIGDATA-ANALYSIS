using System;
using System.IO;

namespace QuadTree
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            QuadTree quadTree = new QuadTree();

            try
            {
                // Read file using StreamReader. Reads file line by line    
                using (StreamReader file = new StreamReader("test.txt"))
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

                        // x, y
                        Position position = new Position(x, y);
                        // z, i 
                        Point point = new Point(position, z, i);

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

        }
    }
}
