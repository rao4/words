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
                    value += Convert.ToInt32(c) - 96;
                }

                if (value == 100) { Console.WriteLine(word); }
            }

            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
        }                             
    }
}
