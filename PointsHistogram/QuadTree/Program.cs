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
                using (StreamReader file = new StreamReader("input.txt"))
                {
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        string[] tokens = ln.Split(' ');

                        // x, y
                        Position position = new Position(Convert.ToDouble(tokens[0]), Convert.ToDouble(tokens[1]));
                        // z, i 
                        Point point = new Point(position, Convert.ToDouble(tokens[2]), Convert.ToInt16(tokens[3]));

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
