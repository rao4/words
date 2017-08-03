using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Words
{
    class Program
    {
        const string basePath = "C:/WorkFile/PlayArea/Words/";

        static void Main(string[] args)
        {
            List<string> words = System.IO.File.ReadAllLines(basePath + "dictionary.csv").ToList();

            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream(basePath + "outPut.csv", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);

            foreach (string word in words)
            {
                int value = 0;
                foreach(char c in word.ToLower())
                {
                    value = value + getNumericValue(c);
                }

                if (value == 100) { Console.WriteLine(word); }
            }

            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();

            Console.ReadKey();
        }

        private static int getNumericValue(char c)
        {
            try
            {
                alphabet letter = (alphabet)Enum.Parse(typeof(alphabet), c.ToString());
                return (int)letter;
            }catch (Exception ex)
            {
                return 0;
            }
        }                          
    }

    enum alphabet { none, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z };
}